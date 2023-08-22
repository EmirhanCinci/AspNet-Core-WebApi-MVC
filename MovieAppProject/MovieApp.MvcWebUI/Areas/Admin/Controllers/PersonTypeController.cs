using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using System.Text.Json;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.PersonType;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class PersonTypeController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public PersonTypeController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpApiService.GetData<ResponseBody<List<PersonTypeItem>>>("/PersonTypes");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewPersonTypeDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var postObj = new { Type = dto.Type };
            var response = await _httpApiService.PostData<ResponseBody<PersonTypeItem>>("/persontypes",
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 201)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Film kişiliği başarıyla eklendi.",
                    PersonTypeId = response.Data.Id,
                    PersonTypeName = response.Data.Type
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
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/PersonTypes/{id}", token.Token);
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Film kişiliği başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePersonTypeDto dto)
        {
            var postObj = new
            {
                Id = dto.Id,
                Type = dto.Type
            };
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var response = await _httpApiService.PutData<ResponseBody<NoContent>>("/PersonTypes",
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 200)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Film kişiliği başarıyla güncellendi. Güncel bilgileri görmek için sayfayı güncelleyiniz."
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
