using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.Admin;

namespace MovieApp.Business.Interfaces
{
    public interface IAdminService
    {
        Task<ApiResponse<AdminDto>> LogInAsync(string userName, string password);
    }
}
