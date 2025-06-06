using NHibernate;
using FunnyWaterDelivery.Database.Models;

namespace FunnyWaterDelivery.Database.Repository;

public sealed class Repository<TModelType, TKeyType> : IRepository<TModelType, TKeyType> where TModelType : DbEntity<TKeyType>
{
    public Repository(ISession session, ITransaction transaction)
    {
        _session = session;
        _transaction = transaction;
    }
    
    private readonly ISession _session;
    private readonly ITransaction _transaction;

    public IQueryable<TModelType> Query => _session.Query<TModelType>().Where(e => !e.Deleted);
    
    public TModelType Get(TKeyType key) => _session.Get<TModelType>(key);
    
    public async Task<TModelType> GetAsync(TKeyType key) => await _session.GetAsync<TModelType>(key);

    public IQueryable<TModelType> Get(IEnumerable<TKeyType> keys) => Query.Where(e => keys.Contains(e.ID)).AsQueryable();

    public void Insert(TModelType obj)
    {
        obj.CreateTime = DateTime.Now;
        _session.Save(obj);
        _transaction.Commit();
    }

    public void Update(TModelType obj)
    {
        obj.UpdateTime = DateTime.Now;
        _session.Update(obj);
        _transaction.Commit();
    }

    public void Delete(TModelType obj)
    {
        obj.Deleted = true;
        Update(obj);
    }

    public void PermanentDelete(TModelType obj)
    {
        _session.Delete(obj);
        _transaction.Commit();
    }

    public void PermanentDeleteAll()
    {
        var all = _session.Query<TModelType>().ToList();
        foreach (var item in all)
        {
            _session.Delete(item);
        }
        _transaction.Commit();
    }
    
    public void Dispose()
    {
        _session?.Dispose();
        _transaction?.Dispose();
    }
}