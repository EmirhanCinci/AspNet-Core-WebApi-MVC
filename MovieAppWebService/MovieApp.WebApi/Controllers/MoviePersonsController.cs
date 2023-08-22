using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.MoviePerson;

namespace MovieApp.WebApi.Controllers
{
    public class MoviePersonsController : BaseController
    {
        private readonly IMoviePersonService _service;
        public MoviePersonsController(IMoviePersonService service)
        {
            _service = service;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MoviePersonDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMoviePersonByIds([FromQuery] int movieId, [FromQuery] int personId, [FromQuery] int personTypeId)
        {
            var response = await _service.GetMoviePersonById(movieId, personId, personTypeId, "Movie", "Person", "PersonType");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MoviePersonDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMoviePersonByMovieIdWithPersonTypeId([FromQuery] int movieId, [FromQuery] int personTypeId)
        {
            var response = await _service.GetMoviePersonsByMovieIdWithPersonTypeIdAsync(movieId, personTypeId, "Movie", "Person", "PersonType");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MoviePersonDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMoviePersonByPersonIdWithPersonTypeId([FromQuery] int personId, [FromQuery] int personTypeId)
        {
            var response = await _service.GetMoviePersonsByPersonIdWithPersonTypeIdAsync(personId, personTypeId, "Movie", "Person", "PersonType");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MoviePersonDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMoviePerson([FromBody] MoviePersonPostDto dto)
        {
            var response = await _service.AddMoviePersonAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetMoviePersonByIds), new { movieId = response.Data.MovieId, personId = response.Data.PersonId, personTypeId = response.Data.PersonTypeId }, response);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteMoviePerson([FromQuery] int movieId, [FromQuery] int personId, [FromQuery] int personTypeId)
        {
            var response = await _service.DeleteMoviePersonAsync(movieId, personId, personTypeId);
            return SendResponse(response);
        }
    }
}
