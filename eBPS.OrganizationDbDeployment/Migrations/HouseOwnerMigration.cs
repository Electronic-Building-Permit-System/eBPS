using FluentMigrator;

namespace eBPS.OrganizationDbDeployment.Migrations
{
    [Migration(202501052225)]
    public class HouseOwnerMigration : Migration
    {
        public override void Up()
        {
            Create.Table("HouseOwner")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("ApplicationId").AsInt32().NotNullable()
           .WithColumn("Salutation").AsInt32().NotNullable()
           .WithColumn("HouseOwnerType").AsInt32().NotNullable()
           .WithColumn("HouseOwnerName").AsString(100).NotNullable()
           .WithColumn("HouseOwnerPhotoPath").AsString().NotNullable()
           .WithColumn("FatherName").AsString(100).NotNullable()
           .WithColumn("GrandFatherName").AsString(100).NotNullable()
           .WithColumn("Tole").AsString(50).NotNullable()
           .WithColumn("CitizenshipNumber").AsString(50).NotNullable()
           .WithColumn("CitizenshipIssueDate").AsDateTime().NotNullable()
           .WithColumn("CitizenshipIssueDistrict").AsDateTime().NotNullable()
           .WithColumn("PhoneNumber").AsString(10).NotNullable()
           .WithColumn("Email").AsString(50).NotNullable()
           .WithColumn("WardNumber").AsInt32().NotNullable()
           .WithColumn("Address").AsString(50).NotNullable();

            Create.ForeignKey("FK_HouseOwner_BuildingApplication")
                .FromTable("HouseOwner").ForeignColumn("ApplicationId")
                .ToTable("BuildingApplication").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("HouseOwner");
        }

    }
}
