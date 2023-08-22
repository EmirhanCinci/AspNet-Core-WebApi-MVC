using AutoMapper;
using Infrastructure.Model;
using MovieApp.Model.Dtos.PersonRating;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class PersonRatingProfile : Profile
    {
        public PersonRatingProfile() 
        {
            CreateMap<PersonRating, PersonRatingDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Nickname))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom( src => src.User.FullName))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.FullName));

            CreateMap<PersonRatingPostDto, PersonRating>();
            CreateMap<PersonRatingPutDto, PersonRating>();
        }
    }
}
