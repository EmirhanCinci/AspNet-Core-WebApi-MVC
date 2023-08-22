using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class PersonRepository : BaseRepository<Person, MovieAppContext>, IPersonRepository
    {
        public async Task<Person> GetPersonByIdAsync(int personId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == personId, includeList);
        }

        public async Task<List<Person>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList)
        {
            return await GetAllAsync(prd => DateTime.Now.Year - prd.Birthdate.Value.Year >= min && DateTime.Now.Year - prd.Birthdate.Value.Year <= max, includeList: includeList);
        }

        public async Task<List<Person>> MostCommentsPersonsAsync(int personTypeId, int personCount, params string[] includeList)
        {
            Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = q => q.OrderByDescending(person => person.PersonRatings.Count);
            return await GetAllAsync(prd => prd.MoviePersons.All(p => p.PersonTypeId == personTypeId), orderBy, personCount, includeList);
        }

        public async Task<List<Person>> MostPointsPersonsAsync(int personTypeId, int personCount, params string[] includeList)
        {
            Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = q => q.OrderByDescending(person => person.PersonRatings.Average(p => p.Point));
            return await GetAllAsync(prd => prd.MoviePersons.All(p => p.PersonTypeId == personTypeId), orderBy, personCount, includeList);
        }
    }
}
