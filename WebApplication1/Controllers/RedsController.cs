using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Controllers
{
    public class RedsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
