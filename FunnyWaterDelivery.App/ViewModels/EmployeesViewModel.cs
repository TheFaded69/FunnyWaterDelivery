using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FunnyWaterDelivery.App.Models.DbServices;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Common.Enums;

namespace FunnyWaterDelivery.App.ViewModels;

public partial class EmployeesViewModel : ObservableObject
{
    private readonly IEmployeeDbService _employeeDbService;
    private readonly IMapper _mapper;

    public EmployeesViewModel(IEmployeeDbService employeeDbService, IMapper mapper)
    {
        _employeeDbService = employeeDbService;
        _mapper = mapper;

        Employees = _employeeDbService.ReadAll();
    }
    
    [ObservableProperty]
    private ObservableCollection<EmployeeRowViewModel> _employees = [];

    [ObservableProperty]
    private EmployeeRowViewModel? _selectedEmployee;
    
    [RelayCommand]
    private void AddEmployee()
    {
        var employeeRowViewModel = new EmployeeRowViewModel
        {
            Name = string.Empty,
            Surname = string.Empty,
            Patronymic = string.Empty,
            EmployeeType = EmployeeType.None,
        };
        Employees.Add(_mapper.Map<EmployeeRowViewModel>(_employeeDbService.Create(employeeRowViewModel)));
    }
    
    [RelayCommand]
    private void SaveChanges()
    {
        foreach (var employeeRowViewModel in Employees) _employeeDbService.Update(employeeRowViewModel);
    }
    
    [RelayCommand]
    private void DeleteEmployee()
    {
        _employeeDbService.Delete(SelectedEmployee);
        Employees.Remove(SelectedEmployee);
    }
}