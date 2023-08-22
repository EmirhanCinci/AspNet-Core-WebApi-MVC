using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.User;

namespace MovieApp.WebApi.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _service.GetUserAsync("MovieRatings", "PersonRatings", "MovieRatings.Movie", "PersonRatings.Person");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{nickname}")]
        public async Task<IActionResult> GetUserById([FromRoute] string nickname)
        {
            var response = await _service.GetUserByIdAsync(nickname, "MovieRatings", "PersonRatings", "MovieRatings.Movie", "PersonRatings.Person");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{fullName}")]
        public async Task<IActionResult> GetUserByFullName([FromRoute] string fullName)
        {
            var response = await _service.GetUsersByFullNameAsync(fullName, "MovieRatings", "PersonRatings", "MovieRatings.Movie", "PersonRatings.Person");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByNicknameWithPasswordAsync([FromQuery] string nickname, [FromQuery] string password)
        {
            var response = await _service.GetUserByNicknameWithPasswordAsync(nickname, password, "MovieRatings", "PersonRatings", "MovieRatings.Movie", "PersonRatings.Person");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewUser([FromBody] UserPostDto dto)
        {
            var response = await _service.AddUserAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetUserById), new { nickname = response.Data.Nickname }, response);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserPutDto dto)
        {
            var response = await _service.UpdateUserAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{nickname}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string nickname)
        {
            var response = await _service.DeleteUserAsync(nickname);
            return SendResponse(response);
        }
    }
}
