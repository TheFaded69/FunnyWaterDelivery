using System.Collections.ObjectModel;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.App.Models.DbServices;

public interface IEmployeeDbService
{
    /// <summary>
    /// Добавить работника
    /// </summary>
    /// <param name="employeeRowViewModel">Работник из таблицы</param>
    DbEmployee Create(EmployeeRowViewModel employeeRowViewModel);
    
    /// <summary>
    /// Обновить работники
    /// </summary>
    /// <param name="employeeRowViewModel"></param>
    DbEmployee Update(EmployeeRowViewModel employeeRowViewModel);
    
    /// <summary>
    /// Удалить работника
    /// </summary>
    /// <param name="id"></param>
    void Delete(EmployeeRowViewModel employeeRowViewModel);
    
    /// <summary>
    /// Считать работника
    /// </summary>
    /// <param name="id">id</param>
    EmployeeRowViewModel Read(Guid id);
    
    /// <summary>
    /// Считать всех работников
    /// </summary>
    /// <returns></returns>
    ObservableCollection<EmployeeRowViewModel> ReadAll();
}