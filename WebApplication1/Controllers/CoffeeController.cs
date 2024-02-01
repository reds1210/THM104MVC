using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CoffeeController : BaseController
    {
        private readonly IDiscountService service;
        private readonly NorthwindContext db;

        public CoffeeController(IDiscountService service,NorthwindContext db)
        {
            this.service = service;
            this.db = db;
        }

        public IActionResult Home()
        {
            ViewBag.something = service.GetDiscountDescription();
            return View();
        }
        public IActionResult About()
        {
            var data = new AboutViewModel()
            {
                Title = "左爺爺咖啡廳",
                SubTitle = "工程師最喜歡聚集的有溫度的場所",
                Description = "低消2萬，謝絕推銷與9527進入"
            };
            ViewBag.data = data;
            return View();
        }
        public IActionResult Product()
        {
            var result = db.Products.Select(p => new ProductViewModel 
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                CategoryName = p.Category.CategoryName,
                SupplierName = p.Supplier.CompanyName
            }).ToList();
            return View(result);
        }
        public IActionResult Suppliers()
        {
            return View();
        }
        public IActionResult Store(string pwd)
        {
            var vipTime = new Dictionary<string, string>
                {
                    {"禮拜一","晚上8點到凌晨3點"},
                    {"禮拜三","晚上8點到凌晨3點"},
                    {"禮拜五","晚上8點到凌晨3點"},
                    {"禮拜六","全日開放"},
                    {"禮拜日","全日開放"},
                };
            var allTime = new Dictionary<string, string>
                {
                    {"禮拜一","早上8點到下午5點"},
                    {"禮拜二","早上8點到下午5點"},
                    {"禮拜三","早上10點到下午5點"},
                    {"禮拜四","早上8點到下午5點"},
                    {"禮拜五","早上8點到下午5點"},
                    {"禮拜六","公休"},
                    {"禮拜日","公休"},
                };

            var data = new StoreViewModel()
            {
                OpenTimeList = pwd == "今晚打老虎" ? vipTime: allTime,
                Phone = pwd == "今晚打老虎" ? "0987654321" : "0204587587",
            };

            return View(data);
        }


    }
}
