using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.Gender;

namespace MovieApp.Business.Interfaces
{
    public interface IGenderService
    {
        Task<ApiResponse<List<GenderDto>>> GetGendersAsync();
        Task<ApiResponse<GenderWithPersonsDto>> GetSingleGenderByIdWithPersonsAsync(int genderId, params string[] includeList);
        Task<ApiResponse<List<GenderWithPersonsDto>>> GetGendersWithPersonsAsync(params string[] includeList);
    }
}
