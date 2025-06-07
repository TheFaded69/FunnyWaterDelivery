using CommunityToolkit.Mvvm.ComponentModel;
using FunnyWaterDelivery.Common.Enums;
using FunnyWaterDelivery.Common.Extensions;

namespace FunnyWaterDelivery.App.ViewModels.RowViewModels;

public partial class EmployeeRowViewModel : BaseRowViewModel
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _surname;

    [ObservableProperty]
    private string _patronymic;
    
    [ObservableProperty]
    private DateTime _dateOfBirth;
    
    public List<EmployeeType> Employees { get; set; } =
    [
        ..Enum.GetValues<EmployeeType>()
    ];
    
    [ObservableProperty]
    private EmployeeType _employeeType;
}