using MovieApp.MvcWebUI.Services.Implementations;
using MovieApp.MvcWebUI.Services.Interfaces;

namespace MovieApp.MvcWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IHttpApiService, HttpApiService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapAreaControllerRoute(
                name: "adminAreaDefault",
                areaName: "admin",
                pattern: "{area}/{controller=Authentication}/{action=LogIn}/{id?}");

            app.Run();
        }
    }
}