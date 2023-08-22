using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.Country;

namespace MovieApp.Business.Interfaces
{
    public interface ICountryService
    {
        Task<ApiResponse<CountryDto>> GetCountryById(int id);
        Task<ApiResponse<CountryWithPersonsDto>> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList);
        Task<ApiResponse<List<CountryDto>>> GetCountriesAsync();
        Task<ApiResponse<List<CountryWithPersonsDto>>> GetCountriesWithPersonsAsync(params string[] includeList);
        Task<ApiResponse<CountryDto>> AddAsync(CountryPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
