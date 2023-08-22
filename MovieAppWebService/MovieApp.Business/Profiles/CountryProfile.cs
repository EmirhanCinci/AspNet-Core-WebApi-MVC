using AutoMapper;
using MovieApp.Model.Dtos.Country;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile() 
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryWithPersonsDto>().ReverseMap();
            CreateMap<CountryPostDto, Country>();
            CreateMap<CountryPutDto, Country>();
        }
    }
}
