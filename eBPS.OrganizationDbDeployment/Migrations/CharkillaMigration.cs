using FluentMigrator;

namespace eBPS.OrganizationDbDeployment.Migrations
{
    [Migration(202501052230)]
    public class CharkillaMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Charkilla")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("ApplicationId").AsInt32().NotNullable()
           .WithColumn("Direction").AsInt32().NotNullable()
           .WithColumn("Side").AsInt32().NotNullable()
           .WithColumn("LandscapeTypeId").AsInt32().NotNullable()
           .WithColumn("CharkillaName").AsString().Nullable() // For Other Landscape except Roads/Main Roads
           .WithColumn("RoadId").AsInt32().Nullable()
           .WithColumn("IsGLD").AsBoolean().Nullable()
           .WithColumn("RoadLength").AsDecimal().Nullable()
           .WithColumn("ProposedROW").AsDecimal().Nullable()
           .WithColumn("ExistingROW").AsDecimal().Nullable()
           .WithColumn("ActualSetback").AsDecimal().NotNullable()
           .WithColumn("StandardSetback").AsDecimal().NotNullable()
           .WithColumn("Kitta").AsString(20).NotNullable();

            Create.ForeignKey("FK_Charkilla_BuildingApplication")
                .FromTable("Charkilla").ForeignColumn("ApplicationId")
                .ToTable("BuildingApplication").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Charkilla");
        }

    }
}
