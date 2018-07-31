using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using core_cf_webui.Models; 

namespace core_cf_webui.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ProductListing(HttpContext httpContext);
    }
}