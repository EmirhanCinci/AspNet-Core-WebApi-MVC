using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
        Task<Gender> GetSingleGenderByIdWithPersonsAsync(int genderId, params string[] includeList);
    }
}
