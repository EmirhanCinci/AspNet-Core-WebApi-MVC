using Infrastructure.Model;
using MovieApp.Model.Dtos.Person;

namespace MovieApp.Model.Dtos.Gender
{
    public class GenderWithPersonsDto : GenderDto, IDto
    {
        public List<PersonDto>? Persons { get; set; }
    }
}
