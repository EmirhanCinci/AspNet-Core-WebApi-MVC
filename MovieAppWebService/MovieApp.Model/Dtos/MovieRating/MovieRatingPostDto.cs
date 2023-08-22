using Infrastructure.Model;

namespace MovieApp.Model.Dtos.MovieRating
{
    public class MovieRatingPostDto : IDto
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
