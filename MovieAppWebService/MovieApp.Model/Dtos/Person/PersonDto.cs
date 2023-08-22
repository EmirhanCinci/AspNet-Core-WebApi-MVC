using Infrastructure.Model;
using MovieApp.Model.Dtos.MoviePerson;
using MovieApp.Model.Dtos.PersonRating;

namespace MovieApp.Model.Dtos.Person
{
    public class PersonDto : IDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? CountryName { get; set; }
        public string? GenderName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public double? Points { get; set; }
        public List<PersonRatingDto>? PersonRatings { get; set; }
        public List<MoviePersonDto>? MoviePersons { get; set; }
    }
}
