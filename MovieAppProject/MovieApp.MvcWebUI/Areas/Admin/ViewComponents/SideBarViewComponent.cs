using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            var adminUser = HttpContext.Session.GetObject<AdminUserItem>("ActiveAdminUser");
            return View(adminUser);
        }
    }
}
