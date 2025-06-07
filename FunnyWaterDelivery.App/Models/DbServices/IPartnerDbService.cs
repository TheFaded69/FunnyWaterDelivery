using System.Collections.ObjectModel;
using FunnyWaterDelivery.App.ViewModels.RowViewModels;
using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.App.Models.DbServices;

public interface IPartnerDbService
{
    /// <summary>
    /// Добавить партнера
    /// </summary>
    /// <param name="partnerRowViewModel">партнера из таблицы</param>
    DbPartner Create(PartnerRowViewModel partnerRowViewModel);
    
    /// <summary>
    /// Обновить партнера
    /// </summary>
    /// <param name="partnerRowViewModel">заказ</param>
    DbPartner Update(PartnerRowViewModel partnerRowViewModel);
    
    /// <summary>
    /// Удалить партнера
    /// </summary>
    /// <param name="partnerRowViewModel">заказ</param>
    void Delete(PartnerRowViewModel partnerRowViewModel);
    
    /// <summary>
    /// Считать партнера
    /// </summary>
    /// <param name="id">id</param>
    PartnerRowViewModel Read(Guid id);
    
    /// <summary>
    /// Считать всех партнеров
    /// </summary>
    /// <returns></returns>
    ObservableCollection<PartnerRowViewModel> ReadAll();
}