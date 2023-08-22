using AutoMapper;
using MovieApp.Model.Dtos.Gender;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Gender, GenderWithPersonsDto>().ReverseMap();
        }
    }
}
