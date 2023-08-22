using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Models.ViewModels;

namespace MovieApp.MvcWebUI.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            var categories = HttpContext.Session.GetObject<List<CategoryItem>>("Categories");
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            if (user != null)
            {
                var response = new PageViewModel()
                {
                    Categories = categories,
                    ActiveUser = user
                };
                return View(response);
            }
            return View(new PageViewModel() { Categories = categories });
        }
    }
}
