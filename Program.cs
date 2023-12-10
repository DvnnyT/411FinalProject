using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<BookStoreDatabaseSettings>(
            builder.Configuration.GetSection("BookStoreDatabase"));

            builder.Services.AddSingleton<BooksService>();

            builder.Services.Configure<ShoppingListDatabaseSettings>(
            builder.Configuration.GetSection("ShoppingListDatabase"));

            builder.Services.AddSingleton<ShoppingListService>();

            builder.Services.AddControllers().AddJsonOptions(
             options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            // Include the BookListsController
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
