using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using core_cf_webui.Models;
using core_cf_webui.Services;

namespace core_cf_webui.Controllers
{
    public class HomeController : Controller
    {
        ProductServiceCommand _products ;

        public HomeController(ProductServiceCommand products)
        {
            _products = products;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
			var result = await _products.ProductListing(this.HttpContext);
            ViewData["products"] = result;
            return View();
        }

		[Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

		[Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
		
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
