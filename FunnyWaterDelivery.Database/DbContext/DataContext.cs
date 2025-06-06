using NHibernate;

namespace FunnyWaterDelivery.Database.DbContext;

public class DataContext(ISession session) : IDataContext
{
    private ITransaction _transaction;
    public ISession Session { get; } = session;

    public void BeginTransactionAsync()
    {
        if (!_transaction.IsActive) _transaction = Session.BeginTransaction();
    }

    public async Task CommitAsync()
    {
        if (_transaction.IsActive) await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        if (_transaction.IsActive) await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        if (_transaction?.IsActive ?? false)
            _transaction.Rollback();

        _transaction?.Dispose();
        Session?.Dispose();
    }
}