using AutoMapper;
using MovieApp.Model.Dtos.Person;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile() 
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.PersonRatings.Average(q => q.Point)));

            CreateMap<PersonPostDto, Person>();
            CreateMap<PersonPutDto, Person>();
        }
    }
}
