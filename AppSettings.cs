using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Reflection;

namespace Numatic.Apps.CodingChallenges
{

    /// <summary>
    /// Static class with constant references to each environment name
    /// </summary>
    public static class Env
    {

        public const string Local = "Local";
        public const string Alpha = "Alpha";
        public const string Beta = "Beta";
        public const string Production = "Production";

    }

    /// <summary>
    /// Application settings from AppSettings.json and AppSettings.{Envrionment}.json
    /// </summary>
    /// <example>
    /// Use dependency injection to get access to configuration from .json files
    ///
    /// <code>
    /// 
    /// using Microsoft.Extensions.Options;
    ///
    /// public class Example
    /// {
    ///
    ///     private readonly AppSettings _settings;
    ///
    ///     public Example(IOptions&lt;AppSettings&gt; settings)
    ///     {
    ///
    ///         _settings = settings.Value;
    ///
    ///     }
    ///
    /// }
    ///
    /// </code>
    /// </example>
    public class AppSettings
    {

        #region Service Specific Settings

        public string DatabaseConnectionString { get; set; }

        #endregion

        #region Boilerplate Specific Settings

        /// <summary>
        /// The name of the service
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The version of the service from .csproj
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// The unique key of the service
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// The name of the host instance
        /// </summary>
        public string Hostname { get; private set; }

        #endregion

        #region Environment Specific Settings

        /// <summary>
        /// Specifies the current environment name.
        /// </summary>
        public string CurrentEnvironment
        {
            get
            {

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (env != null)
                {

                    return env;

                }
                else
                {

                    return Env.Local;

                }

            }

        }

        #endregion

        #region Constructors

        /// <summary>
        /// AppSettings constructor
        /// </summary>
        public AppSettings()
        {

            var assembly = System.Reflection.Assembly.GetEntryAssembly().GetName();

            string version = Environment.GetEnvironmentVariable("SERVICE_VERSION");

            if (string.IsNullOrEmpty(version))
            {

                version = "v0.0.0-local.1";

            }

            this.Version = version;
            this.Name = assembly.Name;

            this.Key = $"{assembly.Name.ToLispCase()}-{version}";

            this.Hostname = Environment.MachineName;

        }

        #endregion

        #region Methods
        public void ValidateSettings()
        {

            AppSettingsValidator validator = new();
            FluentValidation.Results.ValidationResult result = validator.Validate(this);

            if (!result.IsValid)
            {

                foreach (FluentValidation.Results.ValidationFailure error in result.Errors)
                {

                    Console.WriteLine($"AppSettings validation error: {error.ErrorMessage}");

                }

                throw new ConfigurationErrorsException($"AppSettings failed to validate. Please see errors above.");

            }
        }
        #endregion
    }

}
