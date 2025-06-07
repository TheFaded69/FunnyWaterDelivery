using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FunnyWaterDelivery.App.Models.DbServices;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;

namespace FunnyWaterDelivery.App.ViewModels;

public partial class OrdersViewModel  : ObservableObject
{
    private readonly IOrderDbService _orderDbService;
    private readonly IMapper _mapper;

    public OrdersViewModel(IOrderDbService orderDbService, IMapper mapper)
    {
        _orderDbService = orderDbService;
        _mapper = mapper;

        Orders = _orderDbService.ReadAll();
    }
    
    [ObservableProperty]
    private ObservableCollection<OrderRowViewModel> _orders = [];

    [ObservableProperty]
    private OrderRowViewModel? _selectedOrder;
    
    [RelayCommand]
    private void AddOrder()
    {
        var orderRowViewModel = new OrderRowViewModel
        {
            Total = 0,
        };
        Orders.Add(_mapper.Map<OrderRowViewModel>(_orderDbService.Create(orderRowViewModel)));
    }
    
    [RelayCommand]
    private void SaveChanges()
    {
        foreach (var orderRowViewModel in Orders) _orderDbService.Update(orderRowViewModel);
    }
    
    [RelayCommand]
    private void DeleteOrder()
    {
        _orderDbService.Delete(SelectedOrder);
        Orders.Remove(SelectedOrder);
    }
}