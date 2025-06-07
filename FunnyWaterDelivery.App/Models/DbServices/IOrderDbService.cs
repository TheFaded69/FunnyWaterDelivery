using System.Collections.ObjectModel;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.App.Models.DbServices;

public interface IOrderDbService
{
    /// <summary>
    /// Добавить заказ
    /// </summary>
    /// <param name="orderRowViewModel">заказ из таблицы</param>
    DbOrder Create(OrderRowViewModel orderRowViewModel);
    
    /// <summary>
    /// Обновить заказ
    /// </summary>
    /// <param name="orderRowViewModel">заказ</param>
    DbOrder Update(OrderRowViewModel orderRowViewModel);
    
    /// <summary>
    /// Удалить заказ
    /// </summary>
    /// <param name="orderRowViewModel">заказ</param>
    void Delete(OrderRowViewModel orderRowViewModel);
    
    /// <summary>
    /// Считать заказ
    /// </summary>
    /// <param name="id">id</param>
    OrderRowViewModel Read(Guid id);
    
    /// <summary>
    /// Считать все заказы
    /// </summary>
    /// <returns></returns>
    ObservableCollection<OrderRowViewModel> ReadAll();
}