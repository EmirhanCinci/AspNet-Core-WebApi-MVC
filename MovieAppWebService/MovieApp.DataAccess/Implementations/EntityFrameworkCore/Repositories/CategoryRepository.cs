using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : BaseRepository<Category, MovieAppContext>, ICategoryRepository
    {
        public async Task<Category> GetByIdAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == categoryId, includeList);
        }

        public async Task<Category> GetSingleCategoryByIdWithMoviesAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == categoryId, includeList);
        }
    }
}
