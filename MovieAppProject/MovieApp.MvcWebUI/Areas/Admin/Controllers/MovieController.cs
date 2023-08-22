using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Areas.Admin.Models.ViewModels;
using System.Text.Json;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Movie;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpApiService _httpApiService;
        public MovieController(IHttpApiService httpApiService, IWebHostEnvironment webHostEnvironment)
        {
            _httpApiService = httpApiService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseMovie = await _httpApiService.GetData<ResponseBody<List<MovieItem>>>("/Movies");
            var responseCategory = await _httpApiService.GetData<ResponseBody<List<CategoryItem>>>("/Categories");
            var responsePersonTypes = await _httpApiService.GetData<ResponseBody<List<PersonTypeItem>>>("/PersonTypes");
            var responsePersons = await _httpApiService.GetData<ResponseBody<List<PersonItem>>>("/Persons");
            var viewModel = new MovieIndexViewModel() { PersonItems = responsePersons.Data, CategoryList = responseCategory.Data, MovieList = responseMovie.Data, PersonTypeList = responsePersonTypes.Data };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var response = await _httpApiService.GetData<ResponseBody<MovieItem>>($"/Movies/{id}");
            return Json(new
            {
                IsSuccess = true,
                Id = response.Data.Id,
                Name = response.Data.Name,
                Duration = response.Data.Duration,
                ReleaseDate = response.Data.ReleaseDate,
                ShortDescription = response.Data.ShortDescription,
                Description = response.Data.Description,
                Photo = response.Data.Photo,
                Trailer = response.Data.Trailer
            });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewMovieDto dto, IFormFile moviePhoto)
        {
            if (moviePhoto != null)
            {
                if (!moviePhoto.ContentType.StartsWith("image/"))
                {
                    return Json(new { IsSuccess = false, Message = "Film için sadece resim dosyası seçilmelidir." });
                }
                if (moviePhoto.Length > 500 * 1024)
                {
                    return Json(new { IsSuccess = false, Message = "Film için seçilen resim dosyası maksimum 500 KB olabilir." });
                }
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(moviePhoto.FileName)}";
                var picturePath = $@"/admin/movieImages/{randomFileName}";
                var uploadPath = $@"{_webHostEnvironment.ContentRootPath}/wwwroot{picturePath}";
                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    moviePhoto.CopyTo(fs);
                }
                var postObj = new
                {
                    Name = dto.Name,
                    CategoryId = dto.CategoryId,
                    Duration = dto.Duration,
                    ReleaseDate = dto.ReleaseDate,
                    ShortDescription = dto.ShortDescription,
                    Description = dto.Description,
                    Photo = picturePath,
                    Trailer = dto.Trailer 
                };
                var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
                var response = await _httpApiService.PostData<ResponseBody<MovieItem>>("/movies", JsonSerializer.Serialize(postObj), token.Token);
                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Film Başarıyla Kaydedildi",
                          Id = response.Data.Id,
                          Name = response.Data.Name,
                          CategoryName = response.Data.CategoryName,
                          Duration = response.Data.Duration,
                          ReleaseDate = response.Data.ReleaseDate,
                          ShortDescription = response.Data.ShortDescription,
                          Description = response.Data.Description,
                          Photo = response.Data.Photo,
                          Trailer = response.Data.Trailer
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Film için dosya seçilmelidir." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var response = await _httpApiService.DeleteData<ResponseBody<NoContent>>($"/Movies/{id}", token.Token);
            if (response.StatusCode == 200)
            {
                return Json(new { IsSuccess = true, Message = "Film başarıyla silindi." });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt silinemedi.", ErrorMessages = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMovieDto dto, IFormFile moviePhoto)
        {
            if (moviePhoto != null)
            {
                if (!moviePhoto.ContentType.StartsWith("image/"))
                {
                    return Json(new { IsSuccess = false, Message = "Film için sadece resim dosyası seçilmelidir." });
                }
                if (moviePhoto.Length > 500 * 1024)
                {
                    return Json(new { IsSuccess = false, Message = "Film için seçilen resim dosyası maksimum 500 KB olabilir." });
                }
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(moviePhoto.FileName)}";
                var picturePath = $@"/admin/movieImages/{randomFileName}";
                var uploadPath = $@"{_webHostEnvironment.ContentRootPath}/wwwroot{picturePath}";
                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    moviePhoto.CopyTo(fs);
                }
                var postObj = new
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    CategoryId = dto.CategoryId,
                    Duration = dto.Duration,
                    ReleaseDate = dto.ReleaseDate,
                    ShortDescription = dto.ShortDescription,
                    Description = dto.Description,
                    Photo = picturePath,
                    Trailer = dto.Trailer
                };
                var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
                var response = await _httpApiService.PutData<ResponseBody<NoContent>>("/movies", JsonSerializer.Serialize(postObj), token.Token);
                if (response.StatusCode == 200)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Film başarıyla güncellendi. Güncel bilgileri görmek için sayfayı güncelleyiniz.",
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Film için dosya seçilmelidir." });
            }
        }
    }
}
