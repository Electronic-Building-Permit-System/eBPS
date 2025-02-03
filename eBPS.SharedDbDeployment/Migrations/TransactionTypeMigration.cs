using FluentMigrator;


namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501080531)]
    public class TransactionTypeTable:Migration
    {
        public override void Up()
        {
            Create.Table("TransactionType")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Description").AsString(100).NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert initial data

            Insert.IntoTable("TransactionType").Row(new
            {
                Description = "Application for Vacant Land",
            });
            Insert.IntoTable("TransactionType").Row(new
            {
                Description = "Application for Storey Addition",
            });
            Insert.IntoTable("TransactionType").Row(new
            {
                Description = "Application for Super Structure Permit",
            });
            Insert.IntoTable("TransactionType").Row(new
            {
                Description = "Application for Completion",
            });
            Insert.IntoTable("TransactionType").Row(new
            {
                Description = "Application for Niyemit",
            });
            Insert.IntoTable("TransactionType").Row(new
            {
                Description = "Application for Abhilekhekaran",
            });
           
        }


        public override void Down()
        {
            Delete.Table("TransactionType");
        }
    }
}
