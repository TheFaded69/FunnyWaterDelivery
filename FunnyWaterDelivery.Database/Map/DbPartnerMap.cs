using FunnyWaterDelivery.Database.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FunnyWaterDelivery.Database.Map;

public class DbPartnerMap : ClassMapping<DbPartner>
{
    public DbPartnerMap()
    {
        Table("DbPartner");
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
        
        Property(model => model.Name, mapper =>
        {
            mapper.Length(40);
            mapper.NotNullable(true);
        });
        Property(model => model.INN, mapper =>
        {
            mapper.Length(12);
            mapper.NotNullable(true);
        });
        ManyToOne(model => model.Curator, map =>
        {
            map.Column("CuratorId");
            map.Class(typeof(DbEmployee));
            map.NotNullable(false);
            map.Fetch(FetchKind.Join);
        });
    }
}