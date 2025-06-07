using CommunityToolkit.Mvvm.ComponentModel;
using FunnyWaterDelivery.App.Models.DbServices;

namespace FunnyWaterDelivery.App.ViewModels;

public class MainViewModel : ObservableObject
{
    public MainViewModel(IEmployeeDbService employeeDbService, IOrderDbService orderDbService, IPartnerDbService partnerDbService)
    {
        _employeeDbService = employeeDbService;
        _orderDbService = orderDbService;
        _partnerDbService = partnerDbService;
    }
    
    private readonly IEmployeeDbService _employeeDbService;
    private readonly IOrderDbService _orderDbService;
    private readonly IPartnerDbService _partnerDbService;
}