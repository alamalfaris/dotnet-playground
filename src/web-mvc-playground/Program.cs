using Microsoft.Data.SqlClient;
using System.Data;
using web_mvc_playground.Repositories;

namespace web_mvc_playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Ambil connection string dari env var (atau fallback ke appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register IDbConnection sebagai service
            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(connectionString));

            builder.Services.AddScoped<IPubsRepository, PubsRepository>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
