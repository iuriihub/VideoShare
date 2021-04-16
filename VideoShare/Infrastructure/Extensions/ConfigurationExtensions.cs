using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace VideoShare.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void BindConfigurationAndValidate<T>(this IConfiguration config, T settings) where T : class
        {
            // Bind settings
            config.GetSection(typeof(T).Name).Bind(settings);

            // Validate
            var context = new ValidationContext(settings);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(settings, context, results, true);

            var configErrors = results.Select(p => p.ErrorMessage).ToArray();

            if (configErrors.Any())
            {
                var aggrErrors = string.Join(",", configErrors);
                var configType = typeof(T).Name;

                throw new ApplicationException($"Found configuration error(s) in {configType}: {aggrErrors}");
            }
        }
    }
}
