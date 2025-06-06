using FunnyWaterDelivery.Database.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FunnyWaterDelivery.Database.Map;

public class DbOrderMap : ClassMapping<DbOrder>
{
    public DbOrderMap()
    {
        Table("DbOrder");
        Id(model => model.ID, mapper => mapper.Generator(Generators.Guid));
        Property(x => x.Deleted, map =>
        {
            map.Column("Deleted");
            map.NotNullable(true);
        });
        Property(x => x.CreateTime, map =>
        {
            map.Column("CreateTime");
            map.NotNullable(true);
        });
        Property(x => x.UpdateTime, map =>
        {
            map.Column("UpdateTime");
            map.NotNullable(true);
        });
        
        Property(model => model.OrderDate, mapper =>
        {
            mapper.NotNullable(true);
        });
        Property(model => model.Total, mapper =>
        {
            mapper.NotNullable(true);
        });
        ManyToOne(model => model.Employee, map =>
        {
            map.Column("EmployeeId");
            map.Class(typeof(DbEmployee));
            map.NotNullable(true);
            map.Fetch(FetchKind.Join);
        });
        ManyToOne(model => model.Partner, map =>
        {
            map.Column("PartnerId");
            map.Class(typeof(DbPartner));
            map.NotNullable(true);
            map.Fetch(FetchKind.Join);
        });
    }
}