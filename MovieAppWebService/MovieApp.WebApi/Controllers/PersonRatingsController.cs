using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.PersonRating;

namespace MovieApp.WebApi.Controllers
{
    public class PersonRatingsController : BaseController
    {
        private readonly IPersonRatingService _service;
        public PersonRatingsController(IPersonRatingService service)
        {
            _service = service;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonRatingDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetPersonRatingsByUserId([FromRoute] string userId)
        {
            var response = await _service.GetPersonRatingsByUserIdAsync(userId, "User", "Person");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonRatingDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]/{personId}")]
        public async Task<IActionResult> GetPersonRatingByPersonId([FromRoute] int personId)
        {
            var response = await _service.GetPersonRatingsByPersonIdAsync(personId, "User", "Person");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonRatingDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPointsRange([FromQuery] int min, [FromQuery] int max)
        {
            var response = await _service.GetPersonRatingsByPointsRange(min, max, "Person", "User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PersonRatingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonRatingById([FromRoute] int id) 
        {
            var response = await _service.GetOnePersonRatingByIdAsync(id, "Person", "User");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PersonRatingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddPersonRating([FromBody] PersonRatingPostDto dto)
        {
            var response = await _service.AddPersonRatingAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetPersonRatingById), new { id = response.Data.Id }, response);
            }
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdatePersonRating([FromBody] PersonRatingPutDto dto)
        {
            var response = await _service.UpdatePersonRatingAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonRating([FromRoute] int id)
        {
            var response = await _service.DeletePersonRatingAsync(id);
            return SendResponse(response);
        }
    }
}
