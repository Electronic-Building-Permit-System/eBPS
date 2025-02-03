using FluentMigrator;

namespace eBPS.Infrastructure.Migrations
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
                    IsActive = true
                });
                Insert.IntoTable("BuildingPurpose").Row(new
                {
                    Description = "Industrial",
                    IsActive = true
                });
                Insert.IntoTable("BuildingPurpose").Row(new
                {
                    Description = "Government",
                    IsActive = true
                });
                Insert.IntoTable("BuildingPurpose").Row(new
                {
                    Description = "Commercial",
                    IsActive = true
                });
            }
        

            public override void Down()
            {
                Delete.Table("BuildingPurpose");
            }
        }
    
}
