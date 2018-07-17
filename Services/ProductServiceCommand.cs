using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Threading.Tasks;
using System.Collections.Generic;

using core_cf_webui.Models; 

namespace core_cf_webui.Services
{
    public class ProductServiceCommand : HystrixCommand<IEnumerable<Product>>
    {
        IProductService _ProductService;
        ILogger<ProductServiceCommand> _logger;

        public ProductServiceCommand(IHystrixCommandOptions options, IProductService ProductService, ILogger<ProductServiceCommand> logger) : base(options)
        {
            _ProductService = ProductService;
            _logger = logger;
            IsFallbackUserDefined = true;
        }
        public async Task<IEnumerable<Product>> ProductListing()
        {
            return await ExecuteAsync();
        }
        protected override async Task<IEnumerable<Product>> RunAsync()
        {
            var result = await _ProductService.ProductListing();
            _logger.LogInformation("Run: {0}", result);
            return result;
        }

        protected override async Task<IEnumerable<Product>> RunFallbackAsync()
        {
            _logger.LogInformation("RunFallback");
            return await Task.FromResult<IEnumerable<Product>>( new [] { new Product ( 1973, "Big Green Egg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBisQzHwJ5nkDYsP-rB6f_6-0W_jo4HJSQGCVE0zBcf4zsVCZb" ) } ) ;
        }
    }
}