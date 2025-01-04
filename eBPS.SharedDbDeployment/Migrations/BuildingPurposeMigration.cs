using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501021047)]
    public class CreateBuildingPurposeTable : Migration
    {
        public override void Up()
        {
            Create.Table("BuildingPurpose")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Description").AsString(100).NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert initial data

            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Residential",
            });
            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Commercial",
            });
            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Residential Cum Commercial",
            });
            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Industrial",
            });
            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Government",
            });
            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Education",
            });
            Insert.IntoTable("BuildingPurpose").Row(new
            {
                Description = "Health",
            });
        }


        public override void Down()
        {
            Delete.Table("BuildingPurpose");
        }
    }
}
