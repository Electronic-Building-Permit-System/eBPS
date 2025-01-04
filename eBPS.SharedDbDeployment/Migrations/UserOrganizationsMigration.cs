using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    
    [Migration(202412070004)]
    public class CreateUserOrganizationsTable : Migration
    {
        public override void Up()
        {
            Create.Table("UserOrganizations")
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("OrganizationId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("JoinedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime);

            // Composite Primary Key
            Create.PrimaryKey("PK_UserOrganizations")
                .OnTable("UserOrganizations")
                .Columns("UserId", "OrganizationId", "RoleId");

            // Foreign Key to Users
            Create.ForeignKey("FK_UserOrganizations_Users")
                .FromTable("UserOrganizations").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumn("Id");

            // Foreign Key to Organizations
            Create.ForeignKey("FK_UserOrganizations_Organizations")
                .FromTable("UserOrganizations").ForeignColumn("OrganizationId")
                .ToTable("Organizations").PrimaryColumn("Id");

            // Foreign Key to Roles
            Create.ForeignKey("FK_UserOrganizations_Roles")
                .FromTable("UserOrganizations").ForeignColumn("RoleId")
                .ToTable("Roles").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_UserOrganizations_Users").OnTable("UserOrganizations");
            Delete.ForeignKey("FK_UserOrganizations_Organizations").OnTable("UserOrganizations");
            Delete.ForeignKey("FK_UserOrganizations_Roles").OnTable("UserOrganizations");
            Delete.PrimaryKey("PK_UserOrganizations").FromTable("UserOrganizations");
            Delete.Table("UserOrganizations");
        }
    }
}

