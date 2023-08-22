using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Models.ViewModels
{
    public class PageViewModel
    {
        public List<CategoryItem> Categories { get; set; }
        public UserItem? ActiveUser { get; set; }
    }
}
