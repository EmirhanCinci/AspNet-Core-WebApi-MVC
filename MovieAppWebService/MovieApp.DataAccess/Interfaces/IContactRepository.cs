using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<Contact> GetContactByIdAsync(int id, params string[] includeList);
    }
}
