using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class MoviePersonRepository : BaseRepository<MoviePerson, MovieAppContext>, IMoviePersonRepository
    {
        public async Task<MoviePerson> GetMoviePersonsByMovieIdAndPersonIdWithPersonTypeIdAsync(int movieId, int personId, int personTypeId, params string[] includeList)
        {
            return await GetAsync(prd => prd.PersonId == personId && prd.MovieId == movieId && prd.PersonTypeId == personTypeId, includeList);
        }

        public async Task<List<MoviePerson>> GetMoviePersonsByMovieIdWithPersonTypeIdAsync(int movieId, int personTypeId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.MovieId == movieId && prd.PersonTypeId == personTypeId, includeList: includeList);
        }

        public async Task<List<MoviePerson>> GetMoviePersonsByPersonIdWithPersonTypeIdAsync(int personId, int personTypeId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.PersonId == personId && prd.PersonTypeId == personTypeId, includeList: includeList);
        }
    }
}
