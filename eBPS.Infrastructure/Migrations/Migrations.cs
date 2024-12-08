using FluentMigrator;

namespace eBPS.Infrastructure.Migrations
{
    public class AddMigrations
    {
        [Migration(202412070001)]
        public class CreateUsersTable : Migration
        {
            public override void Up()
            {
                Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString(255).NotNullable().Unique()
                .WithColumn("PasswordHash").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable().Unique()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true) // User account active status
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // Account creation timestamp
                .WithColumn("LastLoginAt").AsDateTime().Nullable(); // Last login timestamp (optional)
            }

            public override void Down()
            {
                Delete.Table("Users");
            }
        }

        [Migration(202412070002)]
        public class AddRoles : Migration
        {
            public override void Up()
            {
                Create.Table("Roles")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("Name").AsString(100).NotNullable().Unique() // Role name (e.g., Admin, User)
                    .WithColumn("Description").AsString(255).Nullable(); // Optional description
            }

            public override void Down()
            {
                Delete.Table("Roles");
            }
        }

        [Migration(202412070003)]
        public class AddUserRoles : Migration
        {
            public override void Up()
            {
                Create.Table("UserRoles")
                    .WithColumn("UserId").AsInt32().NotNullable()
                    .WithColumn("RoleId").AsInt32().NotNullable();

                Create.ForeignKey("FK_UserRoles_Users")
                    .FromTable("UserRoles").ForeignColumn("UserId")
                    .ToTable("Users").PrimaryColumn("Id");

                Create.ForeignKey("FK_UserRoles_Roles")
                    .FromTable("UserRoles").ForeignColumn("RoleId")
                    .ToTable("Roles").PrimaryColumn("Id");
            }

            public override void Down()
            {
                Delete.ForeignKey("FK_UserRoles_Users").OnTable("UserRoles");
                Delete.ForeignKey("FK_UserRoles_Roles").OnTable("UserRoles");
                Delete.Table("UserRoles");
            }
        }

        [Migration(202412070004)]
        public class AddRefreshTokens : Migration
        {
            public override void Up()
            {
                Create.Table("RefreshTokens")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("UserId").AsInt32().NotNullable()
                    .WithColumn("Token").AsString(512).NotNullable()
                    .WithColumn("ExpiresAt").AsDateTime().NotNullable()
                    .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

                Create.ForeignKey("FK_RefreshTokens_Users")
                    .FromTable("RefreshTokens").ForeignColumn("UserId")
                    .ToTable("Users").PrimaryColumn("Id");
            }

            public override void Down()
            {
                Delete.ForeignKey("FK_RefreshTokens_Users").OnTable("RefreshTokens");
                Delete.Table("RefreshTokens");
            }
        }
        [Migration(2024071201847)]
        public class AddColumnsToUsersTable : Migration
        {
            public override void Up()
            {
                Alter.Table("Users")
                    .AddColumn("FirstName").AsString(100).NotNullable().WithDefaultValue("Unknown") // Adding FirstName column
                    .AddColumn("LastName").AsString(100).NotNullable().WithDefaultValue("Unknown") // Adding LastName column
                    .AddColumn("PhoneNumber").AsString(10).Nullable(); // Adding PhoneNumber column
            }

            public override void Down()
            {
                Delete.Column("FirstName").FromTable("Users");
                Delete.Column("LastName").FromTable("Users");
                Delete.Column("PhoneNumber").FromTable("Users");
            }
        }

    }
}

