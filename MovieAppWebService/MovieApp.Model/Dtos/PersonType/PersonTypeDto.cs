using Infrastructure.Model;
using MovieApp.Model.Dtos.MoviePerson;
using MovieApp.Model.Entities;

namespace MovieApp.Model.Dtos.PersonType
{
    public class PersonTypeDto : IDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public List<MoviePersonDto>? MoviePersons { get; set; }
    }
}
