using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.User;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Models.ViewModels;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public ProfileController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            var movieRatings = await _httpApiService.GetData<ResponseBody<List<MovieRatingItem>>>($"/MovieRatings/GetMovieRatingsByUserId/{user.Nickname}");
            var personRatings = await _httpApiService.GetData<ResponseBody<List<PersonRatingItem>>>($"/PersonRatings/GetPersonRatingsByUserId/{user.Nickname}");
            var response = new ProfileViewModel()
            {
                User = user,
                MovieRatings = movieRatings.Data,
                PersonRatings = personRatings.Data
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            var postObj = new
            {
                Nickname = dto.Nickname,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Password = dto.Password
            };
            var response = await _httpApiService.PutData<ResponseBody<NoContent>>("/users",
                JsonSerializer.Serialize(postObj));

            if (response.StatusCode == 200)
            {
                var data = new
                {
                    Nickname = dto.Nickname,
                    FullName = dto.Firstname + " " + dto.Lastname,
                    Email = dto.Email,
                    Password = dto.Password
                };
                HttpContext.Session.SetObject("ActiveUser", data);
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Bilgileriniz başarıyla güncellendi."
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
    }
}
