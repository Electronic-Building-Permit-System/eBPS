using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    
    [Migration(202412070002)]
    public class CreateRolesTable : Migration
    {
        public override void Up()
        {
            Create.Table("Roles")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable().Unique()
                .WithColumn("Description").AsString(255).Nullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Admin",
                Description = "Admin Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Designer",
                Description = "Designer Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Registration",
                Description = "Registration Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Field",
                Description = "Field Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Technical",
                Description = "Technical Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Revenue",
                Description = "Revenue Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Executive",
                Description = "Executive Desk",
                IsActive = true
            });

            Insert.IntoTable("Roles").Row(new
            {
                Name = "Archival",
                Description = "Archival Desk",
                IsActive = true
            });
        }

        public override void Down()
        {
            Delete.Table("Roles");
        }
    }
}

