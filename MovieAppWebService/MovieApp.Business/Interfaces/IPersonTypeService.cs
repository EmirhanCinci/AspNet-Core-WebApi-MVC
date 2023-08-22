using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.Person;
using MovieApp.Model.Dtos.PersonType;
using MovieApp.Model.Entities;

namespace MovieApp.Business.Interfaces
{
    public interface IPersonTypeService
    {
        Task<ApiResponse<List<PersonTypeDto>>> GetPersonTypesAsync(params string[] includeList);
        Task<ApiResponse<PersonTypeDto>> GetPersonsByPersonTypeIdAsync(int personTypeId, params string[] includeList);
        Task<ApiResponse<PersonTypeDto>> AddAsync(PersonTypePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(PersonTypePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
