using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Text.Json;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Country;
using Humanizer;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class CountryController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public CountryController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpApiService.GetData<ResponseBody<List<CountryWithPersonsItem>>>("/Countries/GetCountriesWithPersons");
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountry(int id)
        {
            var response = await _httpApiService.GetData<ResponseBody<List<CountryItem>>>($"/countries/{id}");
            return Json(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewCountryDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var postObj = new { Name = dto.Name };
            var response = await _httpApiService.PostData<ResponseBody<CountryItem>>("/countries",
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 201)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Ülke başarıyla eklendi.",
                    CountryId = response.Data.Id,
                    CountryName = response.Data.Name
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
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/Countries/{id}", token.Token);
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Ülke başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var postObj = new
            {
                Id = dto.Id,
                Name = dto.Name
            };
            var response = await _httpApiService.PutData<ResponseBody<NoContent>>("/countries",
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 200)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Ülke başarıyla güncellendi. Güncel bilgileri görmek için sayfayı güncelleyiniz."
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
