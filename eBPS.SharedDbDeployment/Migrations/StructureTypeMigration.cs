using FluentMigrator;


namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501040821)]

    public class StructureTypeTable : Migration
    {
        public override void Up()
        {
            Create.Table("StructureType")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Description").AsString(100).NotNullable()
           .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert initial data

            Insert.IntoTable("StructureType").Row(new
            {
                Description = "RCC Frame Structure",
                IsActive = true
            });
            Insert.IntoTable("StructureType").Row(new
            {
                Description = "Load Bearing",
                IsActive = true
            });
            Insert.IntoTable("StructureType").Row(new
            {
                Description = "Steel Frame Structure",
                IsActive = true
            });

        }


        public override void Down()
        {
            Delete.Table("StructureType");
        }
    }
}
