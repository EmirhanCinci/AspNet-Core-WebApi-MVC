using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Models.ViewModels;

namespace MovieApp.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public CategoryController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Movies(int id)
        {
            var responseCategory = await _httpApiService.GetData<ResponseBody<List<CategoryItem>>>("/Categories");
            var responseCategoryWithMovies = await _httpApiService.GetData<ResponseBody<CategoryWithMoviesItem>>($"/Categories/GetSingleCategoryByIdWithMovies/{id}");
            var response = new CategoryViewModel()
            {
                CategoryList = responseCategory.Data,
                CategoryWithMoviesItem = responseCategoryWithMovies.Data
            };
            
            return View(response);
        }
    }
}
