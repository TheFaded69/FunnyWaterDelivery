using FunnyWaterDelivery.App.ViewModels.RowViewModels;

namespace FunnyWaterDelivery.App.Models.DbServices;

public interface IEmployeeDbService
{
    /// <summary>
    /// Добавить работника
    /// </summary>
    /// <param name="employeeRowViewModel">Работник из таблицы</param>
    void AddEmployee(EmployeeRowViewModel employeeRowViewModel);
}