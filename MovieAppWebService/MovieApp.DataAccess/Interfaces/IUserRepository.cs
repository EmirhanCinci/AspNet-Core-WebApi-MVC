using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByIdAsync(string nickName, params string[] includeList);
        Task<List<User>> GetByFullNameAsync(string fullName, params string[] includeList); 
        Task<User> GetUserByNicknameWithPasswordAsync(string nickName, string password, params string[] includeList);
    }
}
