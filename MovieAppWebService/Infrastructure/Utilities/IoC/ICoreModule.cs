using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
