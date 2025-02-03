using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    
    [Migration(202412070001)]
    public class CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("LastName").AsString(100).NotNullable()
                .WithColumn("PhoneNumber").AsString(10).Nullable()
                .WithColumn("Username").AsString(255).NotNullable().Unique()
                .WithColumn("Email").AsString(255).NotNullable().Unique()
                .WithColumn("PasswordHash").AsString(500).NotNullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("LastLoginAt").AsDateTime().Nullable()
                .WithColumn("LastLoginOrgId").AsInt32().Nullable()
                .WithColumn("LastLoginRoleId").AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}

