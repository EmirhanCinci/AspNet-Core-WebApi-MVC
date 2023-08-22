using Infrastructure.Model;

namespace MovieApp.Model.Dtos.MovieRating
{
    public class MovieRatingDto : IDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
