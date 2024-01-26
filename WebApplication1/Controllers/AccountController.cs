using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly NorthwindContext _db;

        public AccountController(NorthwindContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var aaa = Url.Action("GoogleResponse");
            var p = new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
                //RedirectUri = "https://localhost:8888/account/GoogleResponse"
            };
            return Challenge(p,GoogleDefaults.AuthenticationScheme);
        }


        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var jsondata = result.Principal.Claims.Select(x => new
            {
                x.Value,
                x.Type,
                x.Issuer
            });
            return Json(jsondata);


        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index","home");
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //去資料庫比對資料
            var user = _db.Stuednts.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                ViewBag.Error = "帳號密碼錯誤";
                return View();
            }

            //做一張憑證
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Gender, user.Gender.ToString()),
                new Claim("userId", user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal=new ClaimsPrincipal(claimsIdentity);

            //把憑證給他
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal);


            return RedirectToAction("index","home");
        }
    }
}
