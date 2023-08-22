using AutoMapper;
using MovieApp.Model.Dtos.MovieRating;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class MovieRatingProfile : Profile
    {
        public MovieRatingProfile() 
        {
            CreateMap<MovieRating, MovieRatingDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Nickname))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));

            CreateMap<MovieRatingPostDto, MovieRating>();
            CreateMap<MovieRatingPutDto, MovieRating>();
        }
    }
}
