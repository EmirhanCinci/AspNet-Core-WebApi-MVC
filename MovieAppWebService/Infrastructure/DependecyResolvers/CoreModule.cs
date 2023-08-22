using Infrastructure.CrossCuttingConcerns.Caching.Implementations.Microsoft;
using Infrastructure.CrossCuttingConcerns.Caching.Interfaces;
using Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependecyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
