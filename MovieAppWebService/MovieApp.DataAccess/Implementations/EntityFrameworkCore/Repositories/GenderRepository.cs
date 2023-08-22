using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class GenderRepository : BaseRepository<Gender, MovieAppContext>, IGenderRepository
    {
        public async Task<Gender> GetSingleGenderByIdWithPersonsAsync(int genderId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == genderId, includeList);
        }
    }
}
