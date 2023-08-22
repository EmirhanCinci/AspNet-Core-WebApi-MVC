using AutoMapper;
using MovieApp.Model.Dtos.Contact;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile() 
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

            CreateMap<ContactPostDto, Contact>();
        }
    }
}
