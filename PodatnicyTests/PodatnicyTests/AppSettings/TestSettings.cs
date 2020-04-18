using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;


namespace PodatnicyTests.AppSettings
{
    public class TestSettings
    {
        public static readonly string HostingEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "staging";
        private static string mainConfigFile = "testsettings.json";
        private static IConfiguration configuration;
        static TestSettings()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(mainConfigFile, optional: true, reloadOnChange: false)
                .Build();
        }
        public static string GetValue(string key)
        {
            Assert.IsNotEmpty(configuration[key], $"Expected configuration: {key} in settings file {mainConfigFile} file should not be empty");
            Assert.IsNotNull(configuration[key], $"Expected configuration: {key} in settings file {mainConfigFile} file should not be null");
            return configuration[key];
        }
    }
}
