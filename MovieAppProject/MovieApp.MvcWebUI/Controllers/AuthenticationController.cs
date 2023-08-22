using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.User;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public AuthenticationController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            if (user != null)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            var response = await _httpApiService.GetData<ResponseBody<UserItem>>
            ($"/Users/GetUserByNicknameWithPassword?nickname={dto.UserName}&password={dto.Password}");

            if (response.StatusCode.ToString().StartsWith("2"))
            {
                HttpContext.Session.SetObject("ActiveUser", response.Data);
                return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewUserDto dto)
        {
            var postObj = new
            {
                Nickname = dto.Nickname,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Password = dto.Password
            };
            var response = await _httpApiService.PostData<ResponseBody<UserItem>>("/users",
                JsonSerializer.Serialize(postObj));

            if (response.StatusCode == 201)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Kullanıcı başarıyla eklendi.",
                    Nickname = response.Data.Nickname,
                    FullName = response.Data.FullName,
                    Email = response.Data.Email
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
