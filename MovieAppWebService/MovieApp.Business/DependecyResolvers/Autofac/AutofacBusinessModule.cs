using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Infrastructure.Utilities.Interceptors;
using MovieApp.Business.CustomExceptions;
using MovieApp.Business.Profiles;
using MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts;
using System.Reflection;
using Module = Autofac.Module;

namespace MovieApp.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repositroyAssembly = Assembly.GetAssembly(typeof(MovieAppContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(CategoryProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repositroyAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repositroyAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
