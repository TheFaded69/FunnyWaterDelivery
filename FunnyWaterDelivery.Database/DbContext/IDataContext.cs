using NHibernate;

namespace FunnyWaterDelivery.Database.DbContext;

public interface IDataContext : IDisposable
{
    ISession Session { get; }
    
    void BeginTransactionAsync();
    
    Task CommitAsync();
    
    Task RollbackAsync();
}