using Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Reflection;

namespace AspnetRunBasics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var host = CreateHostBuilder(args).Build();
            //SeedDatabase(host);
            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog(SeriLogger.Configure)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //private static void SeedDatabase(IHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        //        try
        //        {
        //            var aspnetRunContext = services.GetRequiredService<AspnetRunContext>();
        //            AspnetRunContextSeed.SeedAsync(aspnetRunContext, loggerFactory).Wait();
        //        }
        //        catch (Exception exception)
        //        {
        //            var logger = loggerFactory.CreateLogger<Program>();
        //            logger.LogError(exception, "An error occurred seeding the DB.");
        //        }
        //    }
        //}
    }
}
