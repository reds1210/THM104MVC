using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        private HeaderViewModel headerViewModel;
        public BaseController()
        {
            headerViewModel = new HeaderViewModel
            {
                Title = "LEFT GRANDFATHER COFFEE",
                SubTitle = "沒人理我的咖啡廳",
                Menus = new List<MenuOptionViewModel>
                {
                    new MenuOptionViewModel { ActionName = "About",ControllerName = "Coffee",DisplayText = "關於我們"},
                    new MenuOptionViewModel { ActionName = "Home",ControllerName = "Coffee",DisplayText = "首頁"},
                    new MenuOptionViewModel { ActionName = "Product",ControllerName = "Coffee",DisplayText = "產品"},
                    new MenuOptionViewModel { ActionName = "Store",ControllerName = "Coffee",DisplayText = "商店"},
                }
            };
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            TempData["HeaderData"] = headerViewModel;
            base.OnActionExecuting(context);
        }
    }
}
