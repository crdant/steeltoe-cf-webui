using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Threading.Tasks;
using System.Collections.Generic;


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
            return await Task.FromResult<IEnumerable<Product>>( new [] { new Product ( 1973, "Best Selling Product" ) } ) ;
        }
    }
}