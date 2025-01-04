using FluentMigrator;

namespace eBPS.OrganizationDbDeployment.Migrations
{
    [Migration(202501041835)]
    public class CreateBuildingApplicationTable : Migration
    {
        public override void Up()
        {
            Create.Table("BuildingApplication")
           .WithColumn("Salutation").AsInt32().NotNullable()
           .WithColumn("ApplicantName").AsString(100).NotNullable()
           .WithColumn("PhoneNumber").AsString(10).NotNullable()
           .WithColumn("Email").AsString(50).NotNullable()
           .WithColumn("WardNumber").AsInt32().NotNullable()
           .WithColumn("Address").AsString(50).NotNullable()
           .WithColumn("HouseNumber").AsString(20).NotNullable()
           .WithColumn("ApplicantPhotoPath").AsString(250).NotNullable()
           .WithColumn("TransactionType").AsInt32().NotNullable()
           .WithColumn("BuildingPurpose").AsInt32().NotNullable()
           .WithColumn("NBCClass").AsInt32().NotNullable()
           .WithColumn("StructureType").AsInt32().NotNullable()
           .WithColumn("LandUseZone").AsInt32().NotNullable()
           .WithColumn("LandUseSubZone").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("ApplicationDetails");
        }

    }
}
