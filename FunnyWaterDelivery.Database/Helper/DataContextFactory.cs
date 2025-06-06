using System.Diagnostics;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FunnyWaterDelivery.Database.Map;
using FunnyWaterDelivery.Database.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace FunnyWaterDelivery.Database.Helper;

public class DataContextFactory(IConfiguration configuration) : IDataContextFactory
{
    public ISessionFactory CreateSessionFactory()
    {
        var connectionString = configuration.GetConnectionString("DBConnection");

        var cfg = new Configuration();
        
        cfg.DataBaseIntegration(x =>
        {
            x.ConnectionString = connectionString;
            x.Dialect<MySQL8Dialect>();
            x.Driver<MySqlDataDriver>();
            x.ConnectionProvider<DriverConnectionProvider>();
            x.LogSqlInConsole = true;
        });
        
        //cfg.AddMappingsFromAssembly(typeof(DbPartnerMap).Assembly);
        cfg.AddResource("FunnyWaterDelivery.Database.Map.DbEmployee.hbm.xml", typeof(DbEmployee).Assembly);
        cfg.AddResource("FunnyWaterDelivery.Database.Map.DbOrder.hbm.xml", typeof(DbOrder).Assembly);
        cfg.AddResource("FunnyWaterDelivery.Database.Map.DbPartner.hbm.xml", typeof(DbPartner).Assembly);
        
        
        /*return Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
            .Mappings(m => AutoMap.AssemblyOf<DbPartnerMap>().Where(t => typeof(DbEntity<Guid>).IsAssignableFrom(t)))
            .ExposeConfiguration(cfg => 
            {
                var update = new SchemaUpdate(cfg);
                update.Execute(false, true);
            })
            .BuildSessionFactory();*/
        
        return cfg.BuildSessionFactory();
    }
}