namespace FunnyWaterDelivery.Database.Models;

/// <summary>
/// Базовая модель таблицы
/// </summary>
/// <typeparam name="TKeyType">Тип данных для ключа, обычно Guid</typeparam>
public abstract class DbEntity<TKeyType>
{
    public virtual TKeyType ID { get; set; }
    
    public virtual bool Deleted { get; set; }
    
    public virtual DateTime CreateTime { get; set; }
    
    public virtual DateTime UpdateTime { get; set; }
    
    
}