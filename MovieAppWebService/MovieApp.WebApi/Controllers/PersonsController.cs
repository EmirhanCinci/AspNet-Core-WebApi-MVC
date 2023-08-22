using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Interfaces;
using MovieApp.Model.Dtos.Person;

namespace MovieApp.WebApi.Controllers
{
    public class PersonsController : BaseController
    {
        private readonly IPersonService _service;
        public PersonsController(IPersonService service)
        {
            _service = service;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var response = await _service.GetPersonsAsync("PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PersonDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            var response = await _service.GetPersonByIdAsync(id, "PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPersonsByAgeRange([FromQuery] int min, [FromQuery] int max)
        {
            var response = await _service.GetPersonsByAgeRangeAsync(min, max, "PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> MostCommentsPersons([FromQuery] int personTypeId, [FromQuery] int personCount)
        {
            var response = await _service.MostCommentsPersonsAsync(personTypeId, personCount, "PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return SendResponse(response);
        }
        
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PersonDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("[action]")]
        public async Task<IActionResult> MostPointsPersons([FromQuery] int personTypeId, [FromQuery] int personCount)
        {
            var response = await _service.MostPointsPersonsAsync(personTypeId, personCount, "PersonRatings", "PersonRatings.User", "MoviePersons", "MoviePersons.Movie", "MoviePersons.PersonType", "Country", "Gender");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<PersonDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveNewPerson([FromBody] PersonPostDto dto)
        {
            var response = await _service.AddAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetPersonById), new { id = response.Data.Id }, response);
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
        public async Task<IActionResult> UpdatePerson([FromBody] PersonPutDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            var response = await _service.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
