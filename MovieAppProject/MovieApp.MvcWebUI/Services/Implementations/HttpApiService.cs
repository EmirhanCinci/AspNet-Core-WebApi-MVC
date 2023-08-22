using Microsoft.Net.Http.Headers;
using MovieApp.MvcWebUI.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MovieApp.MvcWebUI.Services.Implementations
{
    public class HttpApiService : IHttpApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // DELETE 
        public async Task<T> DeleteData<T>(string endPoint, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{BaseAddress.MovieAppWebService}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } }
            };

            if (!string.IsNullOrEmpty(token))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }

        // GET
        public async Task<T> GetData<T>(string endPoint, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{BaseAddress.MovieAppWebService}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } }
            };

            if (!string.IsNullOrEmpty(token))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }

        // POST
        public async Task<T> PostData<T>(string endPoint, string jsonData, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{BaseAddress.MovieAppWebService}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrEmpty(token))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }

        // PUT
        public async Task<T> PutData<T>(string endPoint, string jsonData, string token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{BaseAddress.MovieAppWebService}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrEmpty(token))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }
    }
}
