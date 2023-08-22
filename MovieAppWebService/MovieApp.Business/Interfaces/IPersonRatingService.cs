using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.MovieRating;
using MovieApp.Model.Dtos.PersonRating;

namespace MovieApp.Business.Interfaces
{
    public interface IPersonRatingService
    {
        Task<ApiResponse<List<PersonRatingDto>>> GetPersonRatingsByUserIdAsync(string userId, params string[] includeList);
        Task<ApiResponse<List<PersonRatingDto>>> GetPersonRatingsByPersonIdAsync(int personId, params string[] includeList);
        Task<ApiResponse<List<PersonRatingDto>>> GetPersonRatingsByPointsRange(int min, int max, params string[] includeList);
        Task<ApiResponse<PersonRatingDto>> AddPersonRatingAsync(PersonRatingPostDto dto);
        Task<ApiResponse<NoData>> UpdatePersonRatingAsync(PersonRatingPutDto dto);
        Task<ApiResponse<NoData>> DeletePersonRatingAsync(int id);
        Task<ApiResponse<PersonRatingDto>> GetOnePersonRatingByIdAsync(int id, params string[] includeList);
    }
}
