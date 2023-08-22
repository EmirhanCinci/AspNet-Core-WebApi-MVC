using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IPersonTypeRepository : IBaseRepository<PersonType>
    {
        Task<PersonType> GetPersonTypeByIdAsync(int id);
        Task<PersonType> GetPersonsByPersonTypeIdAsync(int personTypeId, params string[] includeList);
    }
}
