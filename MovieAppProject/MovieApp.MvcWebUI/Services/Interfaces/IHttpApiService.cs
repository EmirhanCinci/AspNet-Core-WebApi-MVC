namespace MovieApp.MvcWebUI.Services.Interfaces
{
    public interface IHttpApiService
    {
        Task<T> GetData<T>(string endPoint, string token = null);
        Task<T> PostData<T>(string endPoint, string jsonData, string token = null);
        Task<T> DeleteData<T>(string endPoint, string token = null);
        Task<T> PutData<T>(string endPoint, string jsonData, string token = null);
    }
}
