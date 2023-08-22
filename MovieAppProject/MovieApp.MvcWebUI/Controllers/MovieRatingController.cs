using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.MovieRating;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Controllers
{
    public class MovieRatingController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public MovieRatingController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewMovieRatingDto dto)
        {
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            var postObj = new
            {
                UserId = user.Nickname,
                MovieId = dto.MovieId,
                Comment = dto.Comment,
                Point = dto.Point,
            };
            var response = await _httpApiService.PostData<ResponseBody<MovieRatingItem>>("/MovieRatings",
                JsonSerializer.Serialize(postObj));

            if (response.StatusCode == 201)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Yorumunuz başarıyla eklendi.",
                    UserName = response.Data.UserName,
                    MovieId = response.Data.MovieId,
                    Comment = response.Data.Comment,
                    Point = response.Data.Point,
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
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/MovieRatings/{id}");
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Yorum başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }
    }
}
