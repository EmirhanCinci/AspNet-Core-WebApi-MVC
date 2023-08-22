using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class CommentController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public CommentController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonRatings(int id)
        {
            var response = await _httpApiService.GetData<ResponseBody<List<PersonRatingItem>>>($"/PersonRatings/GetPersonRatingByPersonId/{id}");
            return Json(new { IsSuccess = true, data = response.Data });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonComment(int id)
        {
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/PersonRatings/{id}");
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Yorum başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Yorum silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovieComment(int id)
        {
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/MovieRatings/{id}");
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Yorum başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Yorum silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }
    }
}
