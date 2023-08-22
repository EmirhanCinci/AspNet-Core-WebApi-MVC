using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Models.ViewModels
{
    public class MovieCommentViewModel
    {
        public UserItem User { get; set; }
        public MovieItem Movie { get; set; }
    }
}
