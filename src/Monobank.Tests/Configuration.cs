using Microsoft.Extensions.Configuration;

namespace Monobank.Tests
{
    public class Configuration
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}