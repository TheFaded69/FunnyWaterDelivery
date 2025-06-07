using CommunityToolkit.Mvvm.ComponentModel;
using FunnyWaterDelivery.App.Models.DbServices;

namespace FunnyWaterDelivery.App.ViewModels.RowViewModels;

public partial class OrderRowViewModel : BaseRowViewModel
{
    [ObservableProperty]
    private DateTime _orderDate;
    
    [ObservableProperty]
    private decimal _total;
    
    [ObservableProperty]
    private Guid? _employeeId;

    [ObservableProperty]
    private Guid? _partnerId;
}