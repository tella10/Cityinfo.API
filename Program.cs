using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System;

namespace Cityinfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Logger = NLogBuilder
                .ConfigureNLog("nlog.config")
                .GetCurrentClassLogger();
            try
            {
                Logger.Info("Initializing Application....");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Application Stopped because of exceptions");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseNLog();
                });
    }
}
