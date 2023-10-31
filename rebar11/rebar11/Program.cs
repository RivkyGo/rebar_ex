using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;




using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace rebar11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}


//using MongoDB.Driver;
//using rebar11.Models;
//using rebar11.Data;
//using Microsoft.Extensions.Options;
//using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Hosting;

//namespace rebar11
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {

//            var builder = WebApplication.CreateHost(args);

//            //var builder = WebApplication.CreateBuilder(args);

//            // Register services here
//            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(nameof(MongoDBSettings)));

//            builder.Services.AddSingleton<MongoDBContext>(serviceProvider =>
//            {
//                var settings = serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
//                return new MongoDBContext(settings.ConnectionString, settings.DatabaseName);
//            });

//            // Add controllers
//            builder.Services.AddControllers();

//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new() { Title = "rebar11", Version = "v1" });
//            });

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseSwagger();
//            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "rebar11 v1"));

//            app.UseAuthorization();

//            app.MapControllers();

//            app.Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
