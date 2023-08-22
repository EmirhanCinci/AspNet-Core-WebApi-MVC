using Microsoft.Extensions.DependencyInjection;
using MovieApp.Business.Profiles;

namespace MovieApp.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryProfile));
        }
    }
}
