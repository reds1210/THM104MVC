using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Timers;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class THM104Controller : Controller
    {
        private readonly NorthwindContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<THM104Controller> _logger;

        public THM104Controller(NorthwindContext db, IWebHostEnvironment env,ILogger<THM104Controller> logger)
        {
            _db = db;
            _env = env;
            _logger = logger;
        }

        public IActionResult Delete(int id)
        {
            var student = _db.Stuednts.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                _db.Stuednts.Remove(student);
                _db.SaveChanges();
            }
            return RedirectToAction("students");
        }


        public IActionResult Edit(int id) 
        {
            var result = _db.Stuednts.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return RedirectToAction("students");
            }
            var data = new EditViewModel()
            {
                Id = id,
                Email = result.Email,
                Gender = result.Gender,
                Name = result.Name,
                Password = result.Password,                
                Phone = result.Phone,
                Path = result.PicturePath               
            };
            ViewBag.GenderEnum = Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>().Select(se => new SelectListItem
            {
                Text = se.ToString(),
                Value = ((int)se).ToString()
            });

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            var student = _db.Stuednts.FirstOrDefault(x => x.Id == model.Id);
            if (student == null) return View(model);

            var relativePath = "";
            if (model.File != null)
            {
                //C:\Users\T14 Gen 3\source\repos\WebApplication1\WebApplication1\wwwroot\pic\
                var dir = $"{_env.WebRootPath}";
                //354535-3425435-225-234_2.jpeg
                relativePath = $"/pic/{Guid.NewGuid()}_{model.File.FileName}";


                using (var fs = new FileStream(dir + relativePath, FileMode.Create))
                {
                    model.File.CopyTo(fs);
                }
            }

            student.Email = model.Email;
            student.Gender = model.Gender;
            student.Name = model.Name;
            student.Password = model.Password;
            student.Phone = model.Phone;
            if (!string.IsNullOrEmpty(relativePath))
            {
                student.PicturePath = relativePath;
            }
           

            _db.SaveChanges();
            


            return RedirectToAction("students");
        }
        [ServiceFilter(typeof(TimerActionFilter))]
        public IActionResult Students()
        {
           
            _logger.LogWarning("還敢偷看女學生");
            var result= _db.Stuednts.Select(x => new StudentsViewModel
            {
                Email = x.Email,
                Gender = x.Gender,
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                PicturePath = x.PicturePath,
            }).ToList();

            _logger.LogWarning("還敢偷看女學生",result);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadPdf()
        {
            var fileName = "1122選課須知.pdf";
            var fullpath = $"{_env.WebRootPath}/Pdf/{fileName}";

            var fillBytes = await System.IO.File.ReadAllBytesAsync(fullpath);

            return File(fillBytes, "application/pdf");
        }

        [Authorize(Roles ="Admin")]
        public IActionResult CustomersDisplay()
        {
            _logger.LogDebug("偷偷看CustomersDisplay");
            var result = _db.Customers.Select(x => new CustomersDisplayViewModel
            {
                Phone = x.Phone,
                Address = x.Address,
                City = x.City,
                PostalCode = x.PostalCode,
                Country = x.Country,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                CustomerId = x.CustomerId,
                Fax = x.Fax,
                Region = x.Region,
            }).ToList();
            return View(result);
        }

        public IActionResult Register()
        {
            ViewBag.GenderEnum = Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>().Select(se => new SelectListItem
            {
                Text = se.ToString(),
                Value = ((int)se).ToString()
            });

            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var relativePath = "";
            if (model.File != null)
            {
                //C:\Users\T14 Gen 3\source\repos\WebApplication1\WebApplication1\wwwroot\pic\
                var dir = $"{_env.WebRootPath}";
                //354535-3425435-225-234_2.jpeg
                relativePath = $"/pic/{Guid.NewGuid()}_{model.File.FileName}";


                using (var fs = new FileStream(dir + relativePath, FileMode.Create))
                {
                    model.File.CopyTo(fs);
                }
            }
            _db.Stuednts.Add(new Stuednts
            {
                Email = model.Email,
                Gender = model.Gender,
                Name = model.Name,
                Password = model.Password,
                Phone = model.Phone,
                PicturePath = relativePath
            });
            _db.SaveChanges();
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public string Login(LoginModel model)
        {
            //if (string.IsNullOrEmpty(model.Account)|| string.IsNullOrEmpty(model.Password))
            //{
            //    return "帳號或密碼失敗";
            //}
            if (!ModelState.IsValid)
            {
                var temp = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.ErrorMessage));
                return string.Join(", ", temp);
                //return "帳號或密碼失敗";
            }


            return model.Account + model.Password;
        }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "帳號不填是在三小")]
        public string? Account { get; set; }
        [Required(ErrorMessage = "密碼不填是在哈囉")]
        public string? Password { get; set; }
    }
}
