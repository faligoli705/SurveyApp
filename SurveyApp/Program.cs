using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
 using NLog.Config;
using NLog.Targets;
using NLog.Web;
using SurveyApp;
using NLog;

namespace MyApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Sentry/NLog
            var logger = LogManager.GetCurrentClassLogger();
            #endregion

            try
            {
                logger.Debug("init main");
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Flush();
                LogManager.Shutdown();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureLogging(options => options.ClearProviders())
                .UseNLog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.ConfigureLogging(options => options.ClearProviders());
                    //webBuilder.UseNLog();
                    webBuilder.UseStartup<Startup>();
                });

        private static void UsingCodeConfiguration()
        {
            // Other overloads exist, for example, configure the SDK with only the DSN or no parameters at all.
            var config = new LoggingConfiguration();
     
            config.AddTarget(new DebuggerTarget("Debugger"));
            config.AddTarget(new ColoredConsoleTarget("Console"));

            config.AddRuleForAllLevels("Console");
            config.AddRuleForAllLevels("Debugger");

            LogManager.Configuration = config;
        }
    }
}