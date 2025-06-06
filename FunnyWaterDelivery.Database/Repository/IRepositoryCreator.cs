using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.Database.Repository;

public interface IRepositoryCreator<TModelType, TKeyType> where TModelType : DbEntity<TKeyType>
{
    /// <summary>
    /// Создать репозиторий асинхронно
    /// </summary>
    /// <returns></returns>
    Task<IRepository<TModelType, TKeyType>> CreateRepositoryAsync();
    
    /// <summary>
    /// Создать репозиторий
    /// </summary>
    /// <returns></returns>
    IRepository<TModelType, TKeyType> CreateRepository();
}