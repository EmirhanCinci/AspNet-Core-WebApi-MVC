using AutoMapper;
using MovieApp.Model.Dtos.Movie;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.MovieRatings.Average(prd => prd.Point)));

            CreateMap<MoviePostDto, Movie>();
            CreateMap<MoviePutDto, Movie>();
        }
    }
}
