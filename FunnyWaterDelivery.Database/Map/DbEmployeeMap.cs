using FunnyWaterDelivery.Database.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FunnyWaterDelivery.Database.Map;

public class DbEmployeeMap : ClassMapping<DbEmployee>
{
    public DbEmployeeMap()
    {
        Table("DbEmployee");
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
            mapper.Length(20);
            mapper.NotNullable(true);
        });
        Property(model => model.Surname, mapper =>
        {
            mapper.Length(20);
            mapper.NotNullable(true);
        });
        Property(model => model.Patronymic, mapper =>
        {
            mapper.Length(20);
            mapper.NotNullable(true);
        });
        Property(model => model.EmployeeType, mapper =>
        {
            mapper.NotNullable(true);
        });
        Property(model => model.DateOfBirth, mapper =>
        {
            mapper.NotNullable(true);
        });
    }
}