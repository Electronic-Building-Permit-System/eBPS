using FluentMigrator;

namespace eBPS.OrganizationDbDeployment.Migrations
{
    [Migration(202501052210)]
    public class LandInformationMigration : Migration
    {
        public override void Up()
        {
            Create.Table("LandInformation")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("ApplicationId").AsInt32().NotNullable()
           .WithColumn("MapSheetNumber").AsString(20).NotNullable()
           .WithColumn("LandParcelNumber").AsString(20).NotNullable()
           .WithColumn("Ropani").AsDecimal().NotNullable()
           .WithColumn("Aana").AsDecimal().NotNullable()
           .WithColumn("Paisa").AsDecimal().NotNullable()
           .WithColumn("Daam").AsDecimal().NotNullable()
           .WithColumn("SquareMeter").AsDecimal().NotNullable()
           .WithColumn("SquareFeet").AsDecimal().NotNullable()
           .WithColumn("Remarks").AsString(int.MaxValue).Nullable();

            Create.ForeignKey("FK_LandInformation_BuildingApplication")
                .FromTable("LandInformation").ForeignColumn("ApplicationId")
                .ToTable("BuildingApplication").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("LandInformation");
        }

    }
}
