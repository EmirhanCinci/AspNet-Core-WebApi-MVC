using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.Admin;

namespace MovieApp.WebApi.Controllers
{
    public class AdminsController : BaseController
    {
        private readonly IAdminService _service;
        private readonly IConfiguration _configuration;

        public AdminsController(IAdminService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("gettoken")]
        public async Task<IActionResult> GetToken()
        {
            var accessToken = new JwtGenerator(_configuration).CreateAccessToken();
            ApiResponse<AccessToken> response = new ApiResponse<AccessToken>() { Data = accessToken, StatusCode = 200 };

            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AdminDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string userName, [FromQuery] string password)
        {
            var response = await _service.LogInAsync(userName, password);
            return SendResponse(response);
        }
    }
}
