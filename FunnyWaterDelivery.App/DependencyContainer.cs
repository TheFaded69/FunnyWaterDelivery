using AutoMapper;
using FunnyWaterDelivery.App.Models.Mapper;
using FunnyWaterDelivery.App.ViewModels;
using FunnyWaterDelivery.App.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FunnyWaterDelivery.App;

public class DependencyContainer
{
    public static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        
        //DB
        //services.AddTransient<IDbContext, Mapper>();
        
        //Models
        services.AddSingleton(new MapperConfiguration(cfg => 
        {
            cfg.AddProfile<MapperProfile>();
        }).CreateMapper());
        
        // ViewModels
        services.AddTransient<MainViewModel>();

        // Views
        services.AddTransient<Main>(sp =>
            new Main
            {
                DataContext = sp.GetRequiredService<MainViewModel>()
            });
        
        return services.BuildServiceProvider();
    }
}