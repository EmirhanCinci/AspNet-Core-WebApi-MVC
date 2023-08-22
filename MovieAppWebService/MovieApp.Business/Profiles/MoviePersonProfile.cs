using AutoMapper;
using MovieApp.Model.Dtos.MoviePerson;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class MoviePersonProfile : Profile
    {
        public MoviePersonProfile() 
        {
            CreateMap<MoviePerson, MoviePersonDto>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.FullName))
                .ForMember(dest => dest.PersonTypeName, opt => opt.MapFrom(src => src.PersonType.Type))
                .ForMember(dest => dest.PersonPhoto, opt => opt.MapFrom(src => src.Person.Photo))
                .ForMember(dest => dest.MoviePhoto, opt => opt.MapFrom(src => src.Movie.Photo));

            CreateMap<MoviePersonPostDto, MoviePerson>();
            CreateMap<MoviePersonPutDto, MoviePerson>();
        }
    }
}
