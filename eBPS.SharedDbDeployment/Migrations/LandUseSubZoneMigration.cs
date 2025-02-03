using FluentMigrator;
namespace eBPS.SharedDbDeployment.Migrations
{
        [Migration(202501022219)]
        public class CreateLandUseSubZoneTable : Migration
        {
            public override void Up()
            {
                Create.Table("LandUseSubZone")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Description").AsString(100).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

                // Insert initial data

                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Preserved Monument Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Preserved Cultural Heritage Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Residential Cum Commercial",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Mixed Old Residential Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Commercial Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Densed Mixed Residential Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Other Residential Sub-Zone",
                });   
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Planned Residential Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Government and Semi-Government Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Health Services Sub-Zone",
                }); 
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Educational Sub-Zone",
                }); 
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Police and Army Sub-Zone",
                }); 
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Industrial Sub-Zone",
                }); 
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Green Open Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Park and Jungle",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Cultural, Religious and Archiological Sub-Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Urban Expansion Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Surface Vehicle Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Sport Zone",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Ring-Road Inside",
                });
                Insert.IntoTable("LandUseSubZone").Row(new
                {
                    Description = "Ring-Road Outside",
                });

            }
            public override void Down()
            {
                Delete.Table("LandUseSubZone");
            }
        }
    
}
