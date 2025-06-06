using FluentNHibernate;
using FunnyWaterDelivery.Database.Map;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace FunnyWaterDelivery.Database.Helper;

public class DataContextFactory
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory CreateSessionFactory(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionString");

        var cfg = new Configuration();
        
        cfg.DataBaseIntegration(x =>
        {
            x.ConnectionString = connectionString;
            x.Dialect<MySQLDialect>();
            x.Driver<MySqlDataDriver>();
            //x.ConnectionProvider<DriverConnectionProvider>();
            //x.LogSqlInConsole = true;
        });
        
        cfg.AddMappingsFromAssembly(typeof(DbPartnerMap).Assembly);
        
        _sessionFactory = cfg.BuildSessionFactory();
        
        return _sessionFactory;
    }
}