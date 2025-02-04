using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    
    [Migration(202412070005)]
    public class AddRefreshTokens : Migration
    {
        public override void Up()
        {
            Create.Table("RefreshToken")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("OrganizationId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("Token").AsString(500).NotNullable().Unique()
                .WithColumn("ExpiresAt").AsDateTime().NotNullable()
                .WithColumn("RevokedAt").AsDateTime().Nullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime);

            // Composite foreign key
            Create.ForeignKey("FK_RefreshToken_UserOrganizations")
                .FromTable("RefreshToken").ForeignColumns("UserId", "OrganizationId", "RoleId")
                .ToTable("UserOrganizations").PrimaryColumns("UserId", "OrganizationId", "RoleId");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_RefreshToken_UserOrganizations").OnTable("RefreshToken");
            Delete.Table("RefreshToken");
        }
    }
}

