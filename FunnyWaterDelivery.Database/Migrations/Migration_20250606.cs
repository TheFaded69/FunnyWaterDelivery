using FluentMigrator;

namespace FunnyWaterDelivery.Database.Migrations;

[Migration(20250606)]
public class InitialCreate : Migration
{
    public override void Up()
    {
         // Таблица DbEmployee
        Create.Table("DbEmployee")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(20).NotNullable()
            .WithColumn("Surname").AsString(20).NotNullable()
            .WithColumn("Patronymic").AsString(20).Nullable()
            .WithColumn("EmployeeType").AsInt32().NotNullable()
            .WithColumn("DateOfBirth").AsDateTime().NotNullable()
            .WithColumn("Deleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CreateTime").AsDateTime().NotNullable()
            .WithColumn("UpdateTime").AsDateTime().NotNullable();

        // Таблица DbPartner
        Create.Table("DbPartner")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(20).NotNullable()
            .WithColumn("INN").AsString(12).NotNullable()
            .WithColumn("CuratorId").AsGuid().Nullable() // внешний ключ на DbEmployee
            .WithColumn("Deleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CreateTime").AsDateTime().NotNullable()
            .WithColumn("UpdateTime").AsDateTime().NotNullable();

        // Внешний ключ: CuratorId → DbEmployee.Id
        Create.ForeignKey("FK_DbPartner_CuratorId_DbEmployee_Id")
            .FromTable("DbPartner").InSchema(null).ForeignColumn("CuratorId")
            .ToTable("DbEmployee").InSchema(null).PrimaryColumn("Id");

        // Таблица DbOrder
        Create.Table("DbOrder")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("OrderDate").AsDateTime().NotNullable()
            .WithColumn("Total").AsDecimal(18, 2).NotNullable()
            .WithColumn("EmployeeId").AsGuid().NotNullable() // внешний ключ на DbEmployee
            .WithColumn("PartnerId").AsGuid().NotNullable()  // внешний ключ на DbPartner
            .WithColumn("Deleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CreateTime").AsDateTime().NotNullable()
            .WithColumn("UpdateTime").AsDateTime().NotNullable();

        // Внешний ключ: EmployeeId → DbEmployee.Id
        Create.ForeignKey("FK_DbOrder_EmployeeId_DbEmployee_Id")
            .FromTable("DbOrder").InSchema(null).ForeignColumn("EmployeeId")
            .ToTable("DbEmployee").InSchema(null).PrimaryColumn("Id");

        // Внешний ключ: PartnerId → DbPartner.Id
        Create.ForeignKey("FK_DbOrder_PartnerId_DbPartner_Id")
            .FromTable("DbOrder").InSchema(null).ForeignColumn("PartnerId")
            .ToTable("DbPartner").InSchema(null).PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("DbOrder");
        Delete.Table("DbPartner");
        Delete.Table("DbEmployee");
    }
}