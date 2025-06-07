using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using FunnyWaterDelivery.App.ViewModels;

namespace FunnyWaterDelivery.App.Views;

public partial class PartnersView : UserControl
{
    public PartnersView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<PartnersViewModel>();
    }
}