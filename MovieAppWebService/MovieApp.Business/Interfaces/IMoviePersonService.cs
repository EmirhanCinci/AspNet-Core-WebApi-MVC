using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.MoviePerson;

namespace MovieApp.Business.Interfaces
{
    public interface IMoviePersonService
    {
        Task<ApiResponse<MoviePersonDto>> GetMoviePersonById(int movieId, int personId, int personTypeId, params string[] includeList);
        Task<ApiResponse<List<MoviePersonDto>>> GetMoviePersonsByMovieIdWithPersonTypeIdAsync(int movieId, int personTypeId, params string[] includeList);
        Task<ApiResponse<List<MoviePersonDto>>> GetMoviePersonsByPersonIdWithPersonTypeIdAsync(int personId, int personTypeId, params string[] includeList);
        Task<ApiResponse<MoviePersonDto>> AddMoviePersonAsync(MoviePersonPostDto dto);
        Task<ApiResponse<NoData>> DeleteMoviePersonAsync(int movieId, int personId, int personTypeId);
    }
}
