using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Category;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class CategoryController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public CategoryController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpApiService.GetData<ResponseBody<List<CategoryWithMoviesItem>>>("/Categories/GetCategoriesWithMovies");
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = await _httpApiService.GetData<ResponseBody<CategoryItem>>($"/Categories/{id}");
            return Json(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewCategoryDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var postObj = new { Name = dto.Name };
            var response = await _httpApiService.PostData<ResponseBody<CategoryItem>>("/categories", 
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 201)
            {
                return Json(new 
                { 
                    IsSuccess = true, 
                    Message = "Kategori başarıyla eklendi.", 
                    CategoryId = response.Data.Id,
                    CategoryName = response.Data.Name 
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
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/Categories/{id}", token.Token);
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Kategori başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var postObj = new
            {
                Id = dto.Id,
                Name = dto.Name
            };
            var response = await _httpApiService.PutData<ResponseBody<NoContent>>("/categories",
                JsonSerializer.Serialize(postObj), token.Token);

            if (response.StatusCode == 200)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Kategori başarıyla güncellendi. Güncel bilgileri görmek için sayfayı güncelleyiniz."
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
