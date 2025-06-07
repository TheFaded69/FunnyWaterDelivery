using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using FunnyWaterDelivery.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FunnyWaterDelivery.App.Views;

public partial class OrdersView : UserControl
{
    public OrdersView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<OrdersViewModel>();
    }
}