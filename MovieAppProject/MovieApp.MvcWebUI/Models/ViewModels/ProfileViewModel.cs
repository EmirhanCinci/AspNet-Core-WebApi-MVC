using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Models.ViewModels
{
    public class ProfileViewModel
    {
        public UserItem User { get; set; }
        public List<MovieRatingItem> MovieRatings { get; set; }
        public List<PersonRatingItem> PersonRatings { get; set; }
    }
}
