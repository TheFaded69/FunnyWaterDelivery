using FunnyWaterDelivery.Database.Models;
using NHibernate;

namespace FunnyWaterDelivery.Database.Repository;

public class RepositoryCreator<TModelType, TKeyType>(ISessionFactory sessionFactory) : IRepositoryCreator<TModelType, TKeyType> where TModelType : DbEntity<TKeyType>
{
    public IRepository<TModelType, TKeyType> CreateRepository()
    {
        var session = sessionFactory.OpenSession();
        return new Repository<TModelType, TKeyType>(session, session.BeginTransaction());
    }

    public async Task<IRepository<TModelType, TKeyType>> CreateRepositoryAsync()
    {
        //var session = await _sessionFactory.OpenSessionAsync();
        //return new Repository<TModelType, TKeyType>(session);
        //todo async createRepAsync есть ли вообще?
        throw new NotImplementedException();
    }
}