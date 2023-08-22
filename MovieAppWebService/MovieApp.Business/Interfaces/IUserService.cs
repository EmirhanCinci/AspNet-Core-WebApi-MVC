using Infrastructure.Utilities.ApiResponses;
using MovieApp.Model.Dtos.User;

namespace MovieApp.Business.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<List<UserDto>>> GetUserAsync(params string[] includeList);
        Task<ApiResponse<UserDto>> GetUserByIdAsync(string nickName, params string[] includeList);
        Task<ApiResponse<List<UserDto>>> GetUsersByFullNameAsync(string fullName, params string[] includeList);
        Task<ApiResponse<UserDto>> GetUserByNicknameWithPasswordAsync(string nickname, string password, params string[] includeList);
        Task<ApiResponse<UserDto>> AddUserAsync(UserPostDto dto);
        Task<ApiResponse<NoData>> UpdateUserAsync(UserPutDto dto);
        Task<ApiResponse<NoData>> DeleteUserAsync(string userId);
    }
}
