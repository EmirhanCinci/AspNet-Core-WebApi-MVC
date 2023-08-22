using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Areas.Admin.Models.ViewModels;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Movie;
using System.Text.Json;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Person;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class PersonController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PersonController(IHttpApiService httpApiService, IWebHostEnvironment webHostEnvironment)
        {
            _httpApiService = httpApiService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responsePerson = await _httpApiService.GetData<ResponseBody<List<PersonItem>>>("/Persons");
            var responseCountry = await _httpApiService.GetData<ResponseBody<List<CountryItem>>>("/Countries");
            var responseGender = await _httpApiService.GetData<ResponseBody<List<GenderItem>>>("/Genders");
            var response = new AdminPersonViewModel()
            {
                PersonItems = responsePerson.Data,
                CountryItems = responseCountry.Data,
                GenderItems = responseGender.Data
            };
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPerson(int id)
        {
            var response = await _httpApiService.GetData<ResponseBody<PersonItem>>($"/Persons/{id}");
            return Json(new 
            { 
                IsSuccess = true,  
                Id = response.Data.Id,
                FullName = response.Data.FullName,
                Age = response.Data.Age,
                CountryName = response.Data.CountryName,
                GenderName = response.Data.GenderName,
                ShortDescription = response.Data.ShortDescription,
                Description = response.Data.Description,
                Photo = response.Data.Photo,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/Persons/{id}", token.Token);
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Kişi başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kişi silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewPersonDto dto, IFormFile photo)
        {
            if (photo != null)
            {
                if (!photo.ContentType.StartsWith("image/"))
                {
                    return Json(new { IsSuccess = false, Message = "Kişi için sadece resim dosyası seçilmelidir." });
                }
                if (photo.Length > 500 * 1024)
                {
                    return Json(new { IsSuccess = false, Message = "Kişi için seçilen resim dosyası maksimum 500 KB olabilir." });
                }
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";
                var picturePath = $@"/admin/personImages/{randomFileName}";
                var uploadPath = $@"{_webHostEnvironment.ContentRootPath}/wwwroot{picturePath}";
                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    photo.CopyTo(fs);
                }
                var postObj = new
                {
                    Firstname = dto.Firstname,
                    Lastname = dto.Lastname,
                    BirthDate = dto.Birthdate,
                    CountryId = dto.CountryId,
                    GenderId = dto.GenderId,
                    ShortDescription = dto.ShortDescription,
                    Description = dto.Description,
                    Photo = picturePath
                };
                var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
                var response = await _httpApiService.PostData<ResponseBody<PersonItem>>("/Persons", JsonSerializer.Serialize(postObj), token.Token);
                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Film Başarıyla Kaydedildi",
                          Id = response.Data.Id,
                          FullName = response.Data.FullName,
                          Age = response.Data.Age,
                          CountryName = response.Data.CountryName,
                          GenderName = response.Data.GenderName,
                          ShortDescription = response.Data.ShortDescription,
                          Description = response.Data.Description,
                          Photo = picturePath
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kişi için dosya seçilmelidir." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePersonDto dto, IFormFile photo)
        {
            if (photo != null)
            {
                if (!photo.ContentType.StartsWith("image/"))
                {
                    return Json(new { IsSuccess = false, Message = "Kişi için sadece resim dosyası seçilmelidir." });
                }
                if (photo.Length > 500 * 1024)
                {
                    return Json(new { IsSuccess = false, Message = "Kişi için seçilen resim dosyası maksimum 500 KB olabilir." });
                }
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";
                var picturePath = $@"/admin/personImages/{randomFileName}";
                var uploadPath = $@"{_webHostEnvironment.ContentRootPath}/wwwroot{picturePath}";
                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    photo.CopyTo(fs);
                }
                var postObj = new
                {
                    Id = dto.Id,
                    Firstname = dto.Firstname,
                    Lastname = dto.Lastname,
                    BirthDate = dto.Birthdate,
                    CountryId = dto.CountryId,
                    GenderId = dto.GenderId,
                    ShortDescription = dto.ShortDescription,
                    Description = dto.Description,
                    Photo = picturePath
                };
                var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
                var response = await _httpApiService.PutData<ResponseBody<NoContent>>("/persons", JsonSerializer.Serialize(postObj), token.Token);
                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Kişi başarıyla güncellendi. Güncel bilgileri görmek için sayfayı güncelleyiniz.",
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kişi için dosya seçilmelidir." });
            }
        }
    }
}
