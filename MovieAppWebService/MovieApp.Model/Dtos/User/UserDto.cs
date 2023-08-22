using Infrastructure.Model;
using MovieApp.Model.Dtos.MovieRating;
using MovieApp.Model.Dtos.PersonRating;

namespace MovieApp.Model.Dtos.User
{
    public class UserDto : IDto
    {
        public string Nickname { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public List<MovieRatingDto>? MovieRatings { get; set; }
        public List<PersonRatingDto>? PersonRatings { get; set; }
    }
}
