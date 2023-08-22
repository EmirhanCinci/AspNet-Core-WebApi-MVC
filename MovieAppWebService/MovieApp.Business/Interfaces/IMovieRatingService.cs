using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.MovieRating;

namespace MovieApp.Business.Interfaces
{
    public interface IMovieRatingService
    {
        Task<ApiResponse<List<MovieRatingDto>>> GetMovieRatingsByUserIdAsync(string userId, params string[] includeList);
        Task<ApiResponse<List<MovieRatingDto>>> GetMovieRatingsByMovieIdAsync(int movieId, params string[] includeList);
        Task<ApiResponse<List<MovieRatingDto>>> GetMovieRatingsByPointsRange(int min, int max, params string[] includeList);
        Task<ApiResponse<MovieRatingDto>> AddMovieRatingAsync(MovieRatingPostDto dto);
        Task<ApiResponse<NoData>> UpdateMovieRatingAsync(MovieRatingPutDto dto);
        Task<ApiResponse<NoData>> DeleteMovieRatingAsync(int id);
        Task<ApiResponse<MovieRatingDto>> GetOneMovieRatingByIdAsync(int id, params string[] includeList);
    }
}
