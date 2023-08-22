using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Areas.Admin.Models.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<CategoryItem> CategoryList { get; set; }
        public List<MovieItem> MovieList { get; set; }
        public List<PersonTypeItem> PersonTypeList { get; set; }
        public List<PersonItem> PersonItems { get; set; }
    }
}
