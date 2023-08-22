using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.MoviePerson;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class MoviePersonController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public MoviePersonController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewMoviePersonDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var postObj = new { MovieId = dto.MovieId, PersonId = dto.PersonId, PersonTypeId = dto.PersonTypeId };
            var response = await _httpApiService.PostData<ResponseBody<MoviePersonItem>>("/MoviePersons",
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 201)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "İşlem başarıyla gerçekleşti.",
                    MovieId = response.Data.MovieId,
                    PersonId = response.Data.PersonId,
                    PersonTypeId = response.Data.PersonTypeId
                });
            }
            else
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = response.ErrorMessages
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteMoviePersonDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/MoviePersons?movieId={dto.MovieId}&personId={dto.PersonId}&personTypeId={dto.PersonTypeId}", token.Token);
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "İşlem başarıyla gerçekleşti." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }
    }
}
