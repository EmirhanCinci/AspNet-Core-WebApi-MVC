using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class PersonTypeRepository : BaseRepository<PersonType, MovieAppContext>, IPersonTypeRepository
    {
        public async Task<PersonType> GetPersonsByPersonTypeIdAsync(int personTypeId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == personTypeId, includeList: includeList);
        }

        public async Task<PersonType> GetPersonTypeByIdAsync(int id)
        {
            return await GetAsync(prd => prd.Id == id);
        }
    }
}
