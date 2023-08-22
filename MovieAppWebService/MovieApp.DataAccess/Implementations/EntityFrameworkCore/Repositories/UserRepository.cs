using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class UserRepository : BaseRepository<User, MovieAppContext>, IUserRepository
    {
        public async Task<List<User>> GetByFullNameAsync(string fullName, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Firstname.ToLower() + " " + prd.Lastname.ToLower() == fullName.ToLower(), includeList: includeList);
        }

        public async Task<User> GetByIdAsync(string nickName, params string[] includeList)
        {
            return await GetAsync(prd => prd.Nickname.ToLower() == nickName.ToLower(), includeList);
        }

        public async Task<User> GetUserByNicknameWithPasswordAsync(string nickName, string password, params string[] includeList)
        {
            return await GetAsync(prd => prd.Nickname == nickName && prd.Password == password, includeList);
        }
    }
}
