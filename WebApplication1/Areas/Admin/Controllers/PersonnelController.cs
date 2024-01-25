using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly IEmailService _emailService;

        public PersonnelController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult SendDiscountMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendDiscountMail(SendDiscountMailViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var msg = EmailHelper.GetDiscountTemplate(model.Message);
            _emailService.Send(model.Email,"大大~~大優惠", msg);
            return View();
        }
    }
}
