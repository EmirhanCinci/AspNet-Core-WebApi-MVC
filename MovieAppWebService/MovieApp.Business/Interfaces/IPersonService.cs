using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.Person;

namespace MovieApp.Business.Interfaces
{
    public interface IPersonService
    {
        Task<ApiResponse<List<PersonDto>>> GetPersonsAsync(params string[] includeList);
        Task<ApiResponse<PersonDto>> GetPersonByIdAsync(int personId, params string[] includeList);
        Task<ApiResponse<List<PersonDto>>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList);
        Task<ApiResponse<List<PersonDto>>> MostCommentsPersonsAsync(int personTypeId, int personCount, params string[] includeList);
        Task<ApiResponse<List<PersonDto>>> MostPointsPersonsAsync(int personTypeId, int personCount, params string[] includeList);
        Task<ApiResponse<PersonDto>> AddAsync(PersonPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(PersonPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int personId);
    }
}
