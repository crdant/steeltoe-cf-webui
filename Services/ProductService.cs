using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Steeltoe.Common.Discovery;

using core_cf_webui.Models; 

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
        
		public async Task<IEnumerable<Product>> ProductListing(HttpContext httpContext)
		{
			var token = await httpContext.GetTokenAsync("access_token");
            var client = GetClient(token);
            
			var result = await client.GetStringAsync(PRODUCT_LISTING_URL);
            
            _logger.LogInformation("ProductList: {0}", result);
            return JsonConvert.DeserializeObject<Product[]>(result);;
        }

		private HttpClient GetClient(string token)
        {
           
			var client = new HttpClient(_handler, false);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			return client;
        }
        
    }
}