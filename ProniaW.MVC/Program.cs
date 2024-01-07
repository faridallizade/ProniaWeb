using Microsoft.EntityFrameworkCore;
using ProniaWebApp.DAL.Context;
using ProniaWebApp.DAL.Repositories.Implementations;
using ProniaWebApp.DAL.Repositories.Interfaces;

namespace ProniaW.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();
            app.MapControllerRoute(
                name: "Home",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            app.Run();
        }
    }
}