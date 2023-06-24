using Microsoft.EntityFrameworkCore;
using Puc.Web.Data;

namespace Puc.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var assemblyName = typeof(Program).Assembly.GetName().Name;
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString!, m => m.MigrationsAssembly(assemblyName)));

            var app = builder.Build();

            //using var scope = app.Services.CreateScope();
            //var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            //if (context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.MigrateAsync();
            //}

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //}
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}