using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using Radiant.API.WorkerServices;
using System;
using System.IO;

namespace Radiant.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder().
                 AddJsonFile("appsettings.json").
                 AddJsonFile($"appsettings.{environment}.json", true).
                 AddEnvironmentVariables().Build();

            NLog.GlobalDiagnosticsContext.Set("appbasepath", Directory.GetCurrentDirectory());

            Host.CreateDefaultBuilder(args).
                ConfigureServices((hostContext, services) =>
                {
                    //if (string.Equals(environment, "production", StringComparison.InvariantCultureIgnoreCase))
                    //{
                        //services.AddHostedService<RadiantWorkerService>();
                    //}
                })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                   webBuilder.UseConfiguration(configuration);
                   webBuilder.UseStartup<Startup>();
               }).UseNLog().Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
