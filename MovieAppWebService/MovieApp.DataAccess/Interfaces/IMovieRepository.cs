using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<Movie> GetByIdAsync(int movieId, params string[] includeList);
        Task<List<Movie>> GetMoviesByReleaseDateRangeAsync(DateTime start, DateTime end, params string[] includeList);
        Task<List<Movie>> GetMoviesByDurationRangeAsync(int min, int max, params string[] includeList);
        Task<List<Movie>> MostCommentsFilmsAsync(int filmCount, params string[] includeList);
        Task<List<Movie>> MostPointsFilmsAsync(int filmCount, params string[] includeList);
    }
}
