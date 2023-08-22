using Castle.DynamicProxy;
using Infrastructure.CrossCuttingConcerns.Caching.Interfaces;
using Infrastructure.Utilities.Interceptors;
using Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Aspects.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
