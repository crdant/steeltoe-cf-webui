using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using core_cf_webui.Models;
using core_cf_webui.Services ;

namespace core_cf_webui.Controllers
{
    public class HomeController : Controller
    {
        IProductService _products ;

        public HomeController(IProductService products)
        {
            _products = products;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _products.ProductListing();
            ViewData["products"] = result;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
