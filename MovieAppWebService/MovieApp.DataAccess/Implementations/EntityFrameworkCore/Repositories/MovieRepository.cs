using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class MovieRepository : BaseRepository<Movie, MovieAppContext>, IMovieRepository
    {
        public async Task<Movie> GetByIdAsync(int movieId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == movieId, includeList);
        }

        public async Task<List<Movie>> GetMoviesByDurationRangeAsync(int min, int max, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Duration >= min && prd.Duration <= max, includeList: includeList);
        }

        public async Task<List<Movie>> GetMoviesByReleaseDateRangeAsync(DateTime start, DateTime end, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.ReleaseDate >= start && prd.ReleaseDate <= end, includeList: includeList);
        }

        public async Task<List<Movie>> MostCommentsFilmsAsync(int filmCount, params string[] includeList)
        {
            Func<IQueryable<Movie>, IOrderedQueryable<Movie>> orderBy = q => q.OrderByDescending(movie => movie.MovieRatings.Count);
            return await GetAllAsync(orderBy: orderBy, takeCount: filmCount, includeList: includeList);
        }

        public async Task<List<Movie>> MostPointsFilmsAsync(int filmCount, params string[] includeList)
        {
            Func<IQueryable<Movie>, IOrderedQueryable<Movie>> orderBy = q => q.OrderByDescending(movie => movie.MovieRatings.Average(rating => rating.Point));
            return await GetAllAsync(orderBy: orderBy, takeCount: filmCount, includeList: includeList);
        }
    }
}
