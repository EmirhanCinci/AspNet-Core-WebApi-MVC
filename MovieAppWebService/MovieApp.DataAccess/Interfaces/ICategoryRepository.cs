using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByIdAsync(int categoryId, params string[] includeList);
        Task<Category> GetSingleCategoryByIdWithMoviesAsync(int categoryId, params string[] includeList);
    }
}
