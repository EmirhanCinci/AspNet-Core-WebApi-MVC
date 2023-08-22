using System.Text.Json.Serialization;

namespace Infrastructure.Utilities.ApiResponses
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public List<string>? ErrorMessages { get; set; }

        public static ApiResponse<T> Success(int statusCode, T data)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Data = data };
        }

        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T> { StatusCode = statusCode };
        }

        public static ApiResponse<T> Fail(int statusCode, List<string> errorMessages)
        {
            return new ApiResponse<T> { StatusCode = statusCode, ErrorMessages = errorMessages };
        }

        public static ApiResponse<T> Fail(int statusCode, string errorMessage)
        {
            return new ApiResponse<T> { StatusCode = statusCode, ErrorMessages = new List<string> { errorMessage } };
        }
    }
}
