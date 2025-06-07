using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FunnyWaterDelivery.App.ViewModels.RowViewModels;

public abstract partial class BaseRowViewModel : ObservableObject
{
    [ObservableProperty]
    private Guid _id;

    [ObservableProperty]
    private bool _deleted;

    [ObservableProperty]
    private DateTime _createTime;

    [ObservableProperty]
    private DateTime _updateTime;
}