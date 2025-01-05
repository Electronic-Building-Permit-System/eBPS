using FluentMigrator;

namespace eBPS.OrganizationDbDeployment.Migrations
{
    [Migration(202501041835)]
    public class CreateBuildingApplicationTable : Migration
    {
        public override void Up()
        {
            Create.Table("BuildingApplication")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Salutation").AsInt32().NotNullable()
           .WithColumn("ApplicantName").AsString(100).NotNullable()
           .WithColumn("ApplicantNumber").AsString(100).NotNullable()
           .WithColumn("FatherName").AsString(100).NotNullable()
           .WithColumn("GrandFatherName").AsString(100).NotNullable()
           .WithColumn("Tole").AsString(50).NotNullable()
           .WithColumn("CitizenshipNumber").AsString(50).NotNullable()
           .WithColumn("CitizenshipIssueDate").AsDateTime().NotNullable()
           .WithColumn("CitizenshipIssueDistrict").AsDateTime().NotNullable()
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
           .WithColumn("LandUseSubZone").AsInt32().NotNullable()
           .WithColumn("CreatedDate").AsDateTime().NotNullable()
           .WithColumn("CreatedBy").AsInt32().NotNullable()
           .WithColumn("OrganizationId").AsInt32().NotNullable()
           .WithColumn("TotalLandInRopani").AsDecimal().NotNullable()
           .WithColumn("TotalLandInAana").AsDecimal().NotNullable()
           .WithColumn("TotalLandInPaisa").AsDecimal().NotNullable()
           .WithColumn("TotalLandInDaam").AsDecimal().NotNullable()
           .WithColumn("TotalLandInSquareMeter").AsDecimal().NotNullable()
           .WithColumn("TotalLandInSquareFeet").AsDecimal().NotNullable()
           .WithColumn("LandLongitude").AsDecimal().NotNullable()
           .WithColumn("LandLatitude").AsDecimal().NotNullable()
           .WithColumn("LandSawikWard").AsInt32().NotNullable()
           .WithColumn("LandSawikGabisa").AsString().NotNullable()
           .WithColumn("LandToleName").AsString().NotNullable()
           .WithColumn("LandWard").AsInt32().NotNullable();

            Execute.Sql("DBCC CHECKIDENT ('BuildingApplication', RESEED, 999);");
        }
        public override void Down()
        {
            Delete.Table("ApplicationDetails");
        }

    }
}
