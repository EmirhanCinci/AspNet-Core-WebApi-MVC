using Autofac.Extensions.DependencyInjection;
using Autofac;
using MovieApp.Business;
using MovieApp.WebApi.Middlewares;
using MovieApp.Business.DependecyResolvers.Autofac;
using Infrastructure.DependecyResolvers;
using Infrastructure.Utilities.IoC;
using Infrastructure.Extensions;

namespace MovieApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>
                (containerBuilder => containerBuilder.RegisterModule(new AutofacBusinessModule()));

            builder.Services.AddApiServices(builder.Configuration);
            builder.Services.AddBusinessServices();

            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCustomException();

            app.Run();
        }
    }
}