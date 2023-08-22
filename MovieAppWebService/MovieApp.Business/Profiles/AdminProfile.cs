using AutoMapper;
using MovieApp.Model.Dtos.Admin;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile() 
        {
            CreateMap<Admin, AdminDto>();
            CreateMap<AdminPostDto, Admin>();
            CreateMap<AdminPutDto, Admin>();
        }
    }
}
