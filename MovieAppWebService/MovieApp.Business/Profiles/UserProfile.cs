using AutoMapper;
using MovieApp.Model.Dtos.User;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
        }
    }
}
