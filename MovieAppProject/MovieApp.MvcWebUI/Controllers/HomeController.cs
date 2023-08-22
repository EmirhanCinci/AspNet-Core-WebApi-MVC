using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;

namespace MovieApp.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public HomeController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseMovie = await _httpApiService.GetData<ResponseBody<List<MovieItem>>>("/Movies/MostPointsFilms/4");
            var responseCategory = await _httpApiService.GetData<ResponseBody<List<CategoryItem>>>("/Categories");
            HttpContext.Session.SetObject("Categories", responseCategory.Data);
            return View(responseMovie.Data);
        }
    }
}