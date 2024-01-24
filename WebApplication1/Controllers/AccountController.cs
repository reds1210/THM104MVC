﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async IActionResult Login(LoginViewModel model)
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
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Gender, user.Gender.ToString()),
                new Claim("userId", user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal=new ClaimsPrincipal(claimsIdentity);

            //把憑證給他
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal);




            return View();
        }
    }
}
