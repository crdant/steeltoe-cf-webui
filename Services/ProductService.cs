using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;

namespace core_cf_webui.Services
{
    public class ProductService : IProductService
    {
        DiscoveryHttpClientHandler _handler;
        ILogger<ProductService> _logger;
        private const string PRODUCT_LISTING_URL = "https://core-cf-webapi/api/products";

        public ProductService(IDiscoveryClient client, ILoggerFactory logFactory) 
        {
            _handler =  new DiscoveryHttpClientHandler(client, logFactory.CreateLogger<DiscoveryHttpClientHandler>());
            _logger =  logFactory.CreateLogger<ProductService>();
        }

        public async Task<string> ProductListing()
        {
            var client = GetClient();
            var result = await client.GetStringAsync(PRODUCT_LISTING_URL);
            _logger.LogInformation("ProductList: {0}", result);
            return result;
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient(_handler, false);
            return client;
        }
    }
}