using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Controllers
{
    public class PersonRatingController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public PersonRatingController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewPersonRatingDto dto)
        {
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            var postObj = new
            {
                UserId = user.Nickname,
                PersonId = dto.PersonId,
                Comment = dto.Comment,
                Point = dto.Point,
            };
            var response = await _httpApiService.PostData<ResponseBody<PersonRatingItem>>("/PersonRatings",
                JsonSerializer.Serialize(postObj));

            if (response.StatusCode == 200)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Yorumunuz başarıyla eklendi.",
                    UserName = response.Data.UserName,
                    PersonId = response.Data.PersonId,
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
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/PersonRatings/{id}");
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
