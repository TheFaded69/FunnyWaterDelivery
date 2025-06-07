using AutoMapper;
using FluentMigrator.Runner;
using FunnyWaterDelivery.App.Models.DbServices;
using FunnyWaterDelivery.App.Models.Mapper;
using FunnyWaterDelivery.App.ViewModels;
using FunnyWaterDelivery.App.Views;
using FunnyWaterDelivery.Database.Helper;
using FunnyWaterDelivery.Database.Migrations;
using FunnyWaterDelivery.Database.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace FunnyWaterDelivery.App;

public static class DependencyContainer
{
    public static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        
        //cfg
        services.AddSingleton(AppSettingsLoader.Load());
        
        //DB
        services.AddFluentMigratorCore()
            .ConfigureRunner(runner => runner
                .AddMySql8()
                .WithGlobalConnectionString(provider => provider.GetRequiredService<IConfiguration>().GetConnectionString("DBConnection"))
                .ScanIn(typeof(InitialCreate).Assembly).For.Migrations());
        services.AddSingleton<IDataContextFactory, DataContextFactory>();
        services.AddSingleton<ISessionFactory>(provider => provider.GetRequiredService<IDataContextFactory>().CreateSessionFactory());
        services.AddScoped<ISession>(provider => provider.GetRequiredService<ISessionFactory>().OpenSession());
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(IRepositoryCreator<,>), typeof(RepositoryCreator<,>));
        
        //DB service
        services.AddScoped<IEmployeeDbService, EmployeeDbService>();
        services.AddScoped<IOrderDbService, OrderDbService>();
        services.AddScoped<IPartnerDbService, PartnerDbService>();
        
        //Models
        services.AddSingleton(new MapperConfiguration(cfg => 
        {
            cfg.AddProfile<MapperProfile>();
        }).CreateMapper());
        
        // ViewModels
        services.AddTransient<MainViewModel>();
        services.AddTransient<OrdersViewModel>();
        services.AddTransient<EmployeesViewModel>();
        services.AddTransient<PartnersViewModel>();
        
        // Views
        services.AddTransient<MainView>();
        services.AddTransient<OrdersView>();
        services.AddTransient<EmployeesView>();
        services.AddTransient<PartnersView>();
        
        return services.BuildServiceProvider();
    }
}