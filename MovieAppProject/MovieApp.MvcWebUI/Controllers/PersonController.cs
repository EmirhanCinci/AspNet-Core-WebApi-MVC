using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using MovieApp.MvcWebUI.Models.ViewModels;
using MovieApp.MvcWebUI.Areas.Admin.Extensions;

namespace MovieApp.MvcWebUI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public PersonController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Actors()
        {
            var responseMostPopularActors = await _httpApiService.GetData<ResponseBody<List<PersonItem>>>("/Persons/MostPointsPersons?personTypeId=2&personCount=10");
            var responseMostCommentActors = await _httpApiService.GetData<ResponseBody<List<PersonItem>>>("/Persons/MostCommentsPersons?personTypeId=2&personCount=3");
            var responseActors = await _httpApiService.GetData<ResponseBody<PersonTypeItem>>("/PersonTypes/GetPersonTypeWithMoviePersons/2");
            var data = new PersonViewModel()
            {
                MostCommentActors = responseMostCommentActors.Data,
                MostPopularActors = responseMostPopularActors.Data,
                Actors = responseActors.Data
            };
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Directors()
        {
            var responseMostPopularActors = await _httpApiService.GetData<ResponseBody<List<PersonItem>>>("/Persons/MostPointsPersons?personTypeId=1&personCount=10");
            var responseMostCommentActors = await _httpApiService.GetData<ResponseBody<List<PersonItem>>>("/Persons/MostCommentsPersons?personTypeId=1&personCount=3");
            var responseActors = await _httpApiService.GetData<ResponseBody<PersonTypeItem>>("/PersonTypes/GetPersonTypeWithMoviePersons/1");
            var data = new PersonViewModel()
            {
                MostCommentActors = responseMostCommentActors.Data,
                MostPopularActors = responseMostPopularActors.Data,
                Actors = responseActors.Data
            };
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Actor(int id)
        {
            var responsePersonItem = await _httpApiService.GetData<ResponseBody<PersonItem>>($"/Persons/{id}");
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            if (user == null)
            {
                View(new PersonCommentViewModel { Person = responsePersonItem.Data });
            }
            return View(new PersonCommentViewModel { Person = responsePersonItem.Data, User = user });
        }

        [HttpGet]
        public async Task<IActionResult> Director(int id)
        {
            var response = await _httpApiService.GetData<ResponseBody<PersonItem>>($"/Persons/{id}");
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");
            if (user == null)
            {
                View(new PersonCommentViewModel { Person = response.Data });
            }
            return View(new PersonCommentViewModel { Person = response.Data, User = user });
        }
    }
}
