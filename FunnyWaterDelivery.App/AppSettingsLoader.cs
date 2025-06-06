using System.IO;
using Microsoft.Extensions.Configuration;

namespace FunnyWaterDelivery.App;

public static class AppSettingsLoader
{
    public static IConfiguration Load()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        
        return builder.Build();
    }
}