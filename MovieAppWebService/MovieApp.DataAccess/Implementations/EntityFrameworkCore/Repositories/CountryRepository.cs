using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class CountryRepository : BaseRepository<Country, MovieAppContext>, ICountryRepository
    {
        public async Task<Country> GetByIdAsync(int countryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == countryId, includeList);
        }

        public async Task<Country> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == countryId, includeList);
        }
    }
}
