﻿using FluentMigrator;

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
                    .WithColumn("FirstName").AsString(100).NotNullable()
                    .WithColumn("LastName").AsString(100).NotNullable()
                    .WithColumn("PhoneNumber").AsString(10).Nullable()
                    .WithColumn("Username").AsString(255).NotNullable().Unique()
                    .WithColumn("Email").AsString(255).NotNullable().Unique()
                    .WithColumn("PasswordHash").AsString(500).NotNullable()
                    .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                    .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true)
                    .WithColumn("LastLoginAt").AsDateTime().Nullable();
            }

            public override void Down()
            {
                Delete.Table("Users");
            }
        }

        [Migration(202412070002)]
        public class CreateRolesTable : Migration
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
        public class CreateOrganizationsTable : Migration
        {
            public override void Up()
            {
                Create.Table("Organizations")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("Name").AsString(255).NotNullable().Unique()
                    .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                    .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);
            }

            public override void Down()
            {
                Delete.Table("Organizations");
            }
        }

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

        [Migration(202412142156)]
        public class UpdteRolesTable : Migration
        {
            public override void Up()
            {
                Alter.Table("Roles")
                    .AddColumn("IsActive").AsBoolean().Nullable();
            }

            public override void Down()
            {
                Delete.Column("IsActive").FromTable("Roles");
            }
        }

        [Migration(202412302235)]
        public class UpdateUsersTable : Migration
        {
            public override void Up()
            {
                Alter.Table("Users")
                    .AddColumn("LastLoginOrgId").AsInt32().Nullable()
                    .AddColumn("LastLoginRoleId").AsInt32().Nullable();
            }

            public override void Down()
            {
                Delete.Column("LastLoginOrgId").FromTable("Users");
                Delete.Column("LastLoginRoleId").FromTable("Users");
            }
        }
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
                    .WithColumn("UpdatedAt").AsString(255).Nullable()
                    .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

                Create.ForeignKey("FK_OrganizationsConfig_Organizations")
                    .FromTable("OrganizationsConfig").ForeignColumn("OrganizationId")
                    .ToTable("Organizations").PrimaryColumn("Id");

                // Insert initial data
                Insert.IntoTable("OrganizationsConfig").Row(new
                {
                    OrganizationId = 1,
                    ConnectionString = "Server=.;Database=Kathmandu_Ebps;Integrated Security=true;TrustServerCertificate=True;",
                    OrganizationName = "Kathmandu",
                    CreatedAt = SystemMethods.CurrentDateTime,
                    UpdatedAt = SystemMethods.CurrentDateTime,
                    IsActive = true
                });

                Insert.IntoTable("OrganizationsConfig").Row(new
                {
                    OrganizationId = 2,
                    ConnectionString = "Server=.;Database=Lalitpur_Ebps;Integrated Security=true;TrustServerCertificate=True;",
                    OrganizationName = "Lalitpur",
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
}

