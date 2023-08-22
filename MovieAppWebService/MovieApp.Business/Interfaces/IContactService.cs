using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.Contact;

namespace MovieApp.Business.Interfaces
{
    public interface IContactService
    {
        Task<ApiResponse<List<ContactDto>>> GetContactsAsync(params string[] includeList);
        Task<ApiResponse<ContactDto>> GetContactAsync(int id, params string[] includeList);
        Task<ApiResponse<ContactDto>> AddContactAsync(ContactPostDto dto);
    }
}
