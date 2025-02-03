using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501041939)]
    public class CreateNBCClassTable : Migration
    {
        public override void Up()
        {
            Create.Table("NBCClass")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Description").AsString(100).NotNullable()
           .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert initial data

            Insert.IntoTable("NBCClass").Row(new
            {
                Description = "Class A Building",
                IsActive = true
            });
            Insert.IntoTable("NBCClass").Row(new
            {
                Description = "Class B Building",
                IsActive = true
            });
            Insert.IntoTable("NBCClass").Row(new
            {
                Description = "Class C Building",
                IsActive = true
            });
            Insert.IntoTable("NBCClass").Row(new
            {
                Description = "Class D Building",
                IsActive = true
            });
        }


        public override void Down()
        {
            Delete.Table("NBCClass");
        }
    }
}