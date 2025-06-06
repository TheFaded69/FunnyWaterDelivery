using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.Database.Repository;

public interface IRepository<TModelType, in TKeyType>: IDisposable where TModelType : DbEntity<TKeyType>
{
    /// <summary>
    /// Запрос для извлечения данных без отслеживания
    /// </summary>
    IQueryable<TModelType> Query { get; }
    
    /// <summary>
    /// Получить одну запись по ключу PK
    /// </summary>
    /// <param name="key">ключ PK</param>
    /// <returns>запись</returns>
    Task<TModelType> Get(TKeyType key);
    
    /// <summary>
    /// Получить список записей по списку ключей PK
    /// </summary>
    /// <param name="keys">список ключей PK</param>
    /// <returns>список записей</returns>
    IQueryable<TModelType> Get(IEnumerable<TKeyType> keys);
    
    /// <summary>
    /// Вставить запись
    /// </summary>
    /// <param name="obj">запись</param>
    void Insert(TModelType obj);
    
    /// <summary>
    /// Изменить запись
    /// </summary>
    /// <param name="obj">запись</param>
    void Update(TModelType obj);
    
    /// <summary>
    /// Пометить запись на удаление (soft delete)
    /// </summary>
    /// <param name="obj">запись</param>
    void Delete(TModelType obj);
    
    /// <summary>
    /// Удалить безвозвратно
    /// </summary>
    /// <param name="obj">запись</param>
    void PermanentDelete(TModelType obj);
    
    /// <summary>
    /// Удалить безвозвратно все записи
    /// </summary>
    void PermanentDeleteAll();
}