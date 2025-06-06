using System.Windows;
using FluentMigrator.Runner;
using FluentNHibernate;
using FunnyWaterDelivery.App.Models.DbServices;
using FunnyWaterDelivery.App.ViewModels;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.App.Views;
using FunnyWaterDelivery.Database.Helper;
using FunnyWaterDelivery.Database.Migrations;
using FunnyWaterDelivery.Database.Models;
using FunnyWaterDelivery.Database.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ZstdSharp.Unsafe;

namespace FunnyWaterDelivery.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider;
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        _serviceProvider = DependencyContainer.BuildServiceProvider();
        
        RunMigrations(_serviceProvider);

        var service = _serviceProvider.GetRequiredService<IEmployeeDbService>();
        service.AddEmployee(new EmployeeRowViewModel()
        {
            
        });
        
        var mainWindow = _serviceProvider.GetRequiredService<MainView>();
        mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
        mainWindow.Show();
    }
    
    private void RunMigrations(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        
        runner.MigrateUp();
    }
}