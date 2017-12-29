using System;
using Microsoft.Extensions.Configuration;

using Environment = saycle.server.Helpers.Models.Environment;

namespace saycle.server.Handlers
{
    /// <summary>
    /// Handles configuration access.
    /// </summary>
    public static class ConfigurationProvider
    {
        /// <summary>
        /// Application configuration values.
        /// </summary>
        private static IConfiguration Configuration { get; set; }
        
        /// <summary>
        /// Connection to environment database.
        /// </summary>
        public static string ConnectionString => Configuration.GetConnectionString($"SaycleDatabase{Environment}");

        /// <summary>
        /// Name of the API.
        /// </summary>
        public static string ApplicationName => Configuration["Application:Name"];

        /// <summary>
        /// Environment (development, testing or production).
        /// </summary>
        public static Environment Environment => Enum.Parse<Environment>(Configuration["Application:Environment"]);

        /// <summary>
        /// API Version.
        /// </summary>
        public static string Version => Configuration["Application:Version"];

        /// <summary>
        /// Terms of service for API usage.
        /// </summary>
        public static string Terms => Configuration["Application:Terms"];

        /// <summary>
        /// Contact mailing adress.
        /// </summary>
        public static string Contact => Configuration["About:Contact"];

        /// <summary>
        /// Url of the website.
        /// </summary>
        public static string Url => Configuration["About:Url"];

        /// <summary>
        /// Initializes the handler with the application configuration.
        /// </summary>
        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
