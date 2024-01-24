using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDiscountService service;

        public HomeController(ILogger<HomeController> logger, IDiscountService service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Deny()
        {
            return View();
        }

        public IActionResult GetNumber()
        {
            var result = service.GetNumber();
            return Content(result.ToString());
        }

        public IActionResult Index(int id)
        {
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
