using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<CategoryItem> CategoryList { get; set; }
        public CategoryWithMoviesItem CategoryWithMoviesItem { get; set; }
    }
}
