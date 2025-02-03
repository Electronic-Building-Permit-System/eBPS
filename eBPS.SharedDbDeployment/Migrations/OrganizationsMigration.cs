using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202412070003)]
    public class CreateOrganizationsTable : Migration
    {
        public override void Up()
        {
            Create.Table("Organizations")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Insert.IntoTable("Organizations").Row(new
            {
                Name = "Lalitpur",
            });

            Insert.IntoTable("Organizations").Row(new
            {
                Name = "Suryabinayak",
            });

            Insert.IntoTable("Organizations").Row(new
            {
                Name = "Tokha",
            });

            Insert.IntoTable("Organizations").Row(new
            {
                Name = "Tarkeshwor",
            });

            Insert.IntoTable("Organizations").Row(new
            {
                Name = "Bagamati Gaupalika",
            });
        }

        public override void Down()
        {
            Delete.Table("Organizations");
        }
    }
}

