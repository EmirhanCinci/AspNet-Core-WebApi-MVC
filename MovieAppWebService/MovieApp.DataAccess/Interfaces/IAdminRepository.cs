using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password);
    }
}
