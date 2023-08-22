namespace MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.MovieRating
{
    public class NewMovieRatingDto
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
