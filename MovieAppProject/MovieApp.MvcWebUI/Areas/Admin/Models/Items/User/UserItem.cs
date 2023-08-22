namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class UserItem
    {
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public List<MovieRatingItem> MovieRatings { get; set; }
        public List<PersonRatingItem> PersonRatings { get; set; }
    }
}
