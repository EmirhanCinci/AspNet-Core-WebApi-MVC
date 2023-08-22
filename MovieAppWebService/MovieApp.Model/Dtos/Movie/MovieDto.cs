using Infrastructure.Model;
using MovieApp.Model.Dtos.MoviePerson;
using MovieApp.Model.Dtos.MovieRating;

namespace MovieApp.Model.Dtos.Movie
{
    public class MovieDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string CategoryName { get; set; }
        public int Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public string? Trailer { get; set; }
        public double? Points { get; set; }
        public List<MoviePersonDto>? MoviePersons { get; set; }
        public List<MovieRatingDto>? MovieRatings { get; set; }
    }
}
