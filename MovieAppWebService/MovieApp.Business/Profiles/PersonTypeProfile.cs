using AutoMapper;
using MovieApp.Model.Dtos.PersonType;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class PersonTypeProfile : Profile
    {
        public PersonTypeProfile() 
        {
            CreateMap<PersonType, PersonTypeDto>();
            CreateMap<PersonTypePostDto, PersonType>();
            CreateMap<PersonTypePutDto, PersonType>();
        }
    }
}
