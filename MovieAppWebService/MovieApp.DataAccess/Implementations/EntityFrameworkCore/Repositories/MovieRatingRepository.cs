using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class MovieRatingRepository : BaseRepository<MovieRating, MovieAppContext>, IMovieRatingRepository
    {
        public async Task<List<MovieRating>> GetCommentsByMovieIdAsync(int movieId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.MovieId == movieId, includeList: includeList);
        }

        public async Task<List<MovieRating>> GetCommentsByPointsRangeAsync(int min, int max, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Point >= min && prd.Point <= max, includeList: includeList);
        }

        public async Task<List<MovieRating>> GetCommentsByUserIdAsync(string userId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.UserId.ToLower() == userId.ToLower(), includeList: includeList);
        }

        public async Task<MovieRating> GetMovieRatingByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == id, includeList: includeList);
        }
    }
}
