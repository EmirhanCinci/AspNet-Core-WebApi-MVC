using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country> GetByIdAsync(int countryId, params string[] includeList);
        Task<Country> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList);
    }
}
