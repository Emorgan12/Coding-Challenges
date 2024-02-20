using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;
using System.Threading;

namespace Numatic.Apps.CodingChallenges
{

    /// <summary>
    /// Default program class for dotnet core applications
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Auto reset event object
        /// </summary>
        private static readonly AutoResetEvent AutoResetEvent = new AutoResetEvent(false);

        /// <summary>
        /// Called on startup of the application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            Console.CancelKeyPress += Console_CancelKeyPress;

            var serviceProvider = ConfigureServices(new ServiceCollection())
                .BuildServiceProvider();

            serviceProvider.GetService<IApp>().Run();

            AutoResetEvent.WaitOne();

        }

        /// <summary>
        /// Event called when the console cancel key(s) are pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {

            e.Cancel = true;

            AutoResetEvent.Set();

        }

        /// <summary>
        /// Used to configure services for the application
        /// </summary>
        /// <param name="services"></param>
        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {

            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddOptions();

            services.Configure<AppSettings>(configuration.GetSection("GlobalSettings"));

            services.AddTransient<IApp, App>();

            var settings = services.BuildServiceProvider()
                    .GetService<IOptions<AppSettings>>()
                    .Value;
            settings.ValidateSettings();

            

            return services;

        }

    }

}
