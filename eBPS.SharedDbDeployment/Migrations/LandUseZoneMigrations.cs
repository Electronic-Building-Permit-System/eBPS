using FluentMigrator;


   
    namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501051041)]
    public class LandUseZoneTable : Migration
    {
        public override void Up()
        {
            Create.Table("LandUseZone")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Description").AsString(100).NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert initial data

            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Cultural Heritage Conservation Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Residential Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Preserved Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Institutional Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Industrial Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Urban Expansion Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Surface Vehicle Zone",
            });
            Insert.IntoTable("LandUseZone").Row(new
            {
                Description = "Sport Zone",
            });

        }


        public override void Down()
        {
            Delete.Table("LandUseZone");
        }
    }
}
