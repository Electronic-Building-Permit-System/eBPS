
using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501051147)]
    public class LandscapeTypeTable: Migration
    {
        public override void Up()
            {
                Create.Table("LandscapeType")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Description").AsString(100).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

                // Insert initial data

                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "Main Road",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "Dead End Road",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "Road",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "Other Road",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "House",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "Land",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "School",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                    Description = "Temple",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                Description = "Party Palace",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                Description = "Boundary Wall",
                 });
                Insert.IntoTable("LandscapeType").Row(new
                 {
                Description = "Chowk",
                 });
                Insert.IntoTable("LandscapeType").Row(new
                {
                Description = "Pond",
                }); 
                Insert.IntoTable("LandscapeType").Row(new
                {
                Description = "Rajlulo",
                 }); 
                Insert.IntoTable("LandscapeType").Row(new
                 {
                Description = "Public Land",
                }); 
                Insert.IntoTable("LandscapeType").Row(new
                  {
                Description = "College",
                });
                Insert.IntoTable("LandscapeType").Row(new
                {
                Description = "Gumba",
                });
        }


            public override void Down()
            {
                Delete.Table("LandscapeType");
            }
    }
}
