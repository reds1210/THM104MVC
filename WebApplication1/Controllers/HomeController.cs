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

        [HttpGet]
        public IActionResult SetSession([FromQuery] string key, [FromQuery] string value)
        {
            HttpContext.Session.SetString(key, value);
            return Content($"你已經設定session:{value}");
        }

        [HttpGet]
        public IActionResult GetSession([FromQuery] string key)
        {
            var result = HttpContext.Session.GetString(key);
            return Content($"你session Key:{key}裡面的值:{result}");
        }



        public IActionResult Deny()
        {
            _logger.LogCritical("有人偷襲!不講武德，勸他耗汁為之");
            return View();
        }

        public IActionResult GetNumber()
        {
            var result = service.GetNumber();
            return Content(result.ToString());
        }

        public IActionResult Index(int id)
        {
            _logger.LogWarning("有人來首頁");
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
