using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501041026)]
    public class WardTable : Migration
    {
        public override void Up()
        {
            // Create the Ward table
            Create.Table("Ward")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("WardNumber").AsInt32().NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime)
                 .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert values from 1 to 40
            for (int i = 1; i <= 40; i++)
            {
                Insert.IntoTable("Ward").Row(new
                {
                    WardNumber = i,
                    CreatedAt = SystemMethods.CurrentDateTime,
                });
            }
        }

        public override void Down()
        {
            // Drop the Ward table
            Delete.Table("Ward");
        }
    }
}
