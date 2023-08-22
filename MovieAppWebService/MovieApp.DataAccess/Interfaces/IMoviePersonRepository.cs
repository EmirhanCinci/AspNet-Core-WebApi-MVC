using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IMoviePersonRepository : IBaseRepository<MoviePerson>
    {
        Task<MoviePerson> GetMoviePersonsByMovieIdAndPersonIdWithPersonTypeIdAsync(int movieId, int personId, int personTypeId, params string[] includeList);
        Task<List<MoviePerson>> GetMoviePersonsByMovieIdWithPersonTypeIdAsync(int movieId, int personTypeId, params string[] includeList);
        Task<List<MoviePerson>> GetMoviePersonsByPersonIdWithPersonTypeIdAsync(int personId, int personTypeId, params string[] includeList);
    }
}
