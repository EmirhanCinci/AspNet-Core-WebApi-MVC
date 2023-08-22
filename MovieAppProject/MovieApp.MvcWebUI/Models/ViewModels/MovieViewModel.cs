using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Models.ViewModels
{
    public class MovieViewModel
    {
        public List<CategoryItem> CategoryList { get; set; }
        public List<MovieItem> MovieList { get; set; }
        public List<MovieItem> MostPopularMovies { get; set; }
    }
}
