using Microsoft.AspNetCore.Mvc;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items;
using MovieApp.MvcWebUI.Areas.Admin.Models;
using MovieApp.MvcWebUI.Services.Interfaces;
using Humanizer;
using MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Contact;
using System.Text.Json;
using MovieApp.MvcWebUI.Areas.Admin.Models.Items.Contact;

namespace MovieApp.MvcWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public ContactController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpApiService.GetData<ResponseBody<List<CountryItem>>>("/Countries");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewContactDto dto)
        {
            var postObj = new
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Phone = dto.Phone,
                CountryId = dto.CountryId,
                Subject = dto.Subject,
                Message = dto.Message
            };
            var response = await _httpApiService.PostData<ResponseBody<ContactItem>>("/contacts",
                JsonSerializer.Serialize(postObj));

            if (response.StatusCode == 201)
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Mesajınız başarıyla iletildi. En kısa zamanda size dönüş yapılacaktır.",
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
