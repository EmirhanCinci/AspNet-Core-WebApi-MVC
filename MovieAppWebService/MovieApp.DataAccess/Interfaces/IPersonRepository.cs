using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> GetPersonByIdAsync(int personId, params string[] includeList);
        Task<List<Person>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList);
        Task<List<Person>> MostCommentsPersonsAsync(int personTypeId, int personCount, params string[] includeList);
        Task<List<Person>> MostPointsPersonsAsync(int personTypeId, int personCount, params string[] includeList);
    }
}
