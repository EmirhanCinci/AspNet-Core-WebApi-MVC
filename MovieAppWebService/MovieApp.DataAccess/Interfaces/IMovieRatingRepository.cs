using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IMovieRatingRepository : IBaseRepository<MovieRating>
    {
        Task<MovieRating> GetMovieRatingByIdAsync(int id, params string[] includeList);
        Task<List<MovieRating>> GetCommentsByUserIdAsync(string userId, params string[] includeList);
        Task<List<MovieRating>> GetCommentsByMovieIdAsync(int movieId, params string[] includeList);
        Task<List<MovieRating>> GetCommentsByPointsRangeAsync(int min, int max, params string[] includeList);
    }
}
