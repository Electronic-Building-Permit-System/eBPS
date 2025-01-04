using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    
    [Migration(202412302236)]
    public class AddOrganizationsConfig : Migration
    {
        public override void Up()
        {
            Create.Table("OrganizationsConfig")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("OrganizationId").AsInt32().NotNullable()
                .WithColumn("ConnectionString").AsString(100).NotNullable()
                .WithColumn("OrganizationName").AsString(100).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("UpdatedAt").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            Create.ForeignKey("FK_OrganizationsConfig_Organizations")
                .FromTable("OrganizationsConfig").ForeignColumn("OrganizationId")
                .ToTable("Organizations").PrimaryColumn("Id");

            Insert.IntoTable("OrganizationsConfig").Row(new
            {
                OrganizationId = 1,
                ConnectionString = "Server=.;Database=LalitpurEbps;Integrated Security=true;TrustServerCertificate=True;",
                OrganizationName = "Lalitpur",
                CreatedAt = SystemMethods.CurrentDateTime,
                UpdatedAt = SystemMethods.CurrentDateTime,
                IsActive = true
            });

            Insert.IntoTable("OrganizationsConfig").Row(new
            {
                OrganizationId = 3,
                ConnectionString = "Server=.;Database=TokhaEbps;Integrated Security=true;TrustServerCertificate=True;",
                OrganizationName = "Tokha",
                CreatedAt = SystemMethods.CurrentDateTime,
                UpdatedAt = SystemMethods.CurrentDateTime,
                IsActive = true
            });

            Insert.IntoTable("OrganizationsConfig").Row(new
            {
                OrganizationId = 2,
                ConnectionString = "Server=.;Database=SuryabinayakEbps;Integrated Security=true;TrustServerCertificate=True;",
                OrganizationName = "Suryabinayak",
                CreatedAt = SystemMethods.CurrentDateTime,
                UpdatedAt = SystemMethods.CurrentDateTime,
                IsActive = true
            });

            Insert.IntoTable("OrganizationsConfig").Row(new
            {
                OrganizationId = 4,
                ConnectionString = "Server=.;Database=TarkeshworEbps;Integrated Security=true;TrustServerCertificate=True;",
                OrganizationName = "Tarkeshwor",
                CreatedAt = SystemMethods.CurrentDateTime,
                UpdatedAt = SystemMethods.CurrentDateTime,
                IsActive = true
            });

            Insert.IntoTable("OrganizationsConfig").Row(new
            {
                OrganizationId = 5,
                ConnectionString = "Server=.;Database=BagmatiEbps;Integrated Security=true;TrustServerCertificate=True;",
                OrganizationName = "Bagmati Gaupalika",
                CreatedAt = SystemMethods.CurrentDateTime,
                UpdatedAt = SystemMethods.CurrentDateTime,
                IsActive = true
            });
        }

        public override void Down()
        {
            Delete.Table("OrganizationsConfig");
        }
    }
}

