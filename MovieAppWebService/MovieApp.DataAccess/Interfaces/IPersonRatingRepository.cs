using Infrastructure.DataAccess.Interfaces;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Interfaces
{
    public interface IPersonRatingRepository : IBaseRepository<PersonRating>
    {
        Task<PersonRating> GetPersonRatingByIdAsync(int id, params string[] includeList);
        Task<List<PersonRating>> GetCommentsByUserIdAsync(string userId, params string[] includeList);
        Task<List<PersonRating>> GetCommentsByPersonIdAsync(int personId, params string[] includeList);
        Task<List<PersonRating>> GetCommentsByPointsRangeAsync(int min, int max, params string[] includeList);
    }
}
