using CommunityToolkit.Mvvm.ComponentModel;
using FunnyWaterDelivery.App.Models.DbServices;

namespace FunnyWaterDelivery.App.ViewModels.RowViewModels;

public partial class PartnerRowViewModel : BaseRowViewModel
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _iNn;

    [ObservableProperty]
    private Guid? _employeeId;
}