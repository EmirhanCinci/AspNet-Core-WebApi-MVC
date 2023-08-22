using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.Movie;

namespace MovieApp.WebApi.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MovieDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var response = await _service.GetMoviesAsync("Category", "MovieRatings", "MoviePersons", "MoviePersons.Person", "MoviePersons.PersonType", "MovieRatings.User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MovieDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _service.GetMovieByIdAsync(id, "Category", "MovieRatings", "MoviePersons", "MoviePersons.Person", "MoviePersons.PersonType", "MovieRatings.User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MovieDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMoviesByReleaseDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var response = await _service.GetMoviesByReleaseDateRangeAsync(start, end, "Category", "MovieRatings", "MoviePersons", "MoviePersons.Person", "MoviePersons.PersonType", "MovieRatings.User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MovieDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMoviesByDurationRange([FromQuery] int min, [FromQuery] int max)
        {
            var response = await _service.GetMoviesByDurationRangeAsync(min, max, "Category", "MovieRatings", "MoviePersons", "MoviePersons.Person", "MoviePersons.PersonType", "MovieRatings.User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MovieDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{filmCount}")]
        public async Task<IActionResult> MostCommentsFilms([FromRoute] int filmCount)
        {
            var response = await _service.MostCommentsFilmsAsync(filmCount, "Category", "MovieRatings", "MoviePersons", "MoviePersons.Person", "MoviePersons.PersonType", "MovieRatings.User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MovieDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{filmCount}")]
        public async Task<IActionResult> MostPointsFilms([FromRoute] int filmCount)
        {
            var response = await _service.MostPointsFilmsAsync(filmCount, "Category", "MovieRatings", "MoviePersons", "MoviePersons.Person", "MoviePersons.PersonType", "MovieRatings.User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<MovieDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveNewMovie([FromBody] MoviePostDto dto)
        {
            var response = await _service.AddAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateMovie([FromBody] MoviePutDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            var response = await _service.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}