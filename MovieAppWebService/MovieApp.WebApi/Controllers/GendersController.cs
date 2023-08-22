using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.Gender;

namespace MovieApp.WebApi.Controllers
{
    public class GendersController : BaseController
    {
        private readonly IGenderService _service;
        public GendersController(IGenderService service)
        {
            _service = service;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<GenderDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var response = await _service.GetGendersAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<GenderWithPersonsDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetGendersWithPersonsAsync()
        {
            var response = await _service.GetGendersWithPersonsAsync("Persons", "Persons.Country");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GenderWithPersonsDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{genderId}")]
        public async Task<IActionResult> GetSingleGenderByIdWithPersons([FromRoute] int genderId)
        {
            var response = await _service.GetSingleGenderByIdWithPersonsAsync(genderId, "Persons", "Persons.Country");
            return SendResponse(response);
        }
    }
}
