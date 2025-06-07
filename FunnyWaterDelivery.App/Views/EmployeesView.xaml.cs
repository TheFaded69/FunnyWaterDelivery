using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using FunnyWaterDelivery.App.ViewModels;

namespace FunnyWaterDelivery.App.Views;

public partial class EmployeesView : UserControl
{
    public EmployeesView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<EmployeesViewModel>();
    }
}