using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using MovieApp.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Repositories
{
    public class ContactRepository : BaseRepository<Contact, MovieAppContext>, IContactRepository
    {
        public async Task<Contact> GetContactByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == id, includeList);
        }
    }
}
