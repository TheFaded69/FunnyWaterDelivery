using System.Windows;
using FunnyWaterDelivery.App.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FunnyWaterDelivery.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        ServiceProvider = DependencyContainer.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<Main>();
        mainWindow.Show();
    }
}