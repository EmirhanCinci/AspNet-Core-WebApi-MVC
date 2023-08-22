using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class AdminRepository : BaseRepository<Admin, MovieAppContext>, IAdminRepository
    {
        public Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            return GetAsync(prd => prd.Username == userName && prd.Password == password);
        }
    }
}
