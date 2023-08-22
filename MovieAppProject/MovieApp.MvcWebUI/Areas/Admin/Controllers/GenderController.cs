using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Filters;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;

namespace MovieApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class GenderController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public GenderController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpApiService.GetData<ResponseBody<List<GenderWithPersonsItem>>>("/Genders/GetGendersWithPersons");
            return View(response.Data);
        }
    }
}
