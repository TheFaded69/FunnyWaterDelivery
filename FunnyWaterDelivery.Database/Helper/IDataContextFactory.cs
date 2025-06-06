using NHibernate;

namespace FunnyWaterDelivery.Database.Helper;

public interface IDataContextFactory
{
    ISessionFactory CreateSessionFactory();
}