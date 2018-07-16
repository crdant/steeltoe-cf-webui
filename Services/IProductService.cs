using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_cf_webui.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ProductListing();
    }
}