using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Models.ViewModels;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;

namespace MovieApp.MvcWebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public MovieController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseMostPopularMovies = await _httpApiService.GetData<ResponseBody<List<MovieItem>>>("/Movies/MostPointsFilms/4");
            var responseCategory = await _httpApiService.GetData<ResponseBody<List<CategoryItem>>>("/Categories");
            var responseMovies = await _httpApiService.GetData<ResponseBody<List<MovieItem>>>("/Movies");
            var data = new MovieViewModel()
            {
                CategoryList = responseCategory.Data,
                MostPopularMovies = responseMostPopularMovies.Data,
                MovieList = responseMovies.Data
            };
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Movie(int id)
        {
            var responseMovie = await _httpApiService.GetData<ResponseBody<MovieItem>>($"/Movies/{id}");
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            if (user == null)
            {
                View(new MovieCommentViewModel { Movie = responseMovie.Data});
            }
            return View(new MovieCommentViewModel { Movie = responseMovie.Data, User = user });
        }
    }
}
