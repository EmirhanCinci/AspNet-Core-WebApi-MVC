namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class CategoryWithMoviesItem : CategoryItem
    {
        public List<MovieItem> Movies { get; set; }
    }
}
