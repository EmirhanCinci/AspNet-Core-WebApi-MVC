using Infrastructure.Model;
using MovieApp.Model.Dtos.Person;

namespace MovieApp.Model.Dtos.Country
{
    public class CountryWithPersonsDto : CountryDto, IDto
    {
        public List<PersonDto>? Persons { get; set; }
    }
}
