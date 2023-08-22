using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;
using MovieApp.MvcWebUI.Services.Interfaces;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            var response = await _httpApiService.GetData<ResponseBody<AdminUserItem>>
                ($"/Admins/logIn?userName={dto.UserName}&password={dto.Password}");

            if (response.StatusCode.ToString().StartsWith("2"))
            {
                HttpContext.Session.SetObject("ActiveAdminUser", response.Data);
                await GetTokenAndSetInSession();
                return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }
        }

        public async Task GetTokenAndSetInSession()
        {
            var response = await _httpApiService.GetData<ResponseBody<AccessTokenItem>>(@"/admins/gettoken");
            HttpContext.Session.SetObject("AccessToken", response.Data);
        }
    }
}
