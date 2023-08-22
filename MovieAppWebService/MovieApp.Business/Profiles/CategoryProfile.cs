using AutoMapper;
using MovieApp.Model.Dtos.Category;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithMoviesDto>().ReverseMap();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }
    }
}
