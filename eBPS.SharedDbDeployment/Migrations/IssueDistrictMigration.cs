using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501080547)]
    public class IssueDistrictTable : Migration
    {
        public override void Up()
        {
            Create.Table("IssueDistrict")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Description").AsString(100).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert all districts one by one
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Achham" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Arghakhanchi" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Baglung" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Baitadi" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Bajhang" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Bajura" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Banke" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Bara" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Bardiya" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Bhaktapur" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Bhojpur" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Chitwan" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dadeldhura" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dailekh" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dang" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Darchula" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dhading" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dhankuta" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dhanusha" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dolakha" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Dolpa" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Doti" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Gorkha" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Gulmi" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Humla" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Ilam" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Jajarkot" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Jhapa" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Jumla" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kailali" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kalikot" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kanchanpur" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kapilvastu" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kaski" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kathmandu" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Kavrepalanchok" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Khotang" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Lalitpur" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Lamjung" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Mahottari" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Makwanpur" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Manang" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Morang" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Mugu" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Mustang" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Myagdi" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Nawalparasi (Bardaghat Susta East)" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Nawalparasi (Bardaghat Susta West)" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Nuwakot" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Okhaldhunga" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Palpa" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Panchthar" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Parbat" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Parsa" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Pyuthan" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Ramechhap" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Rasuwa" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Rautahat" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Rolpa" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Rukum East" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Rukum West" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Rupandehi" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Salyan" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Sankhuwasabha" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Saptari" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Sarlahi" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Sindhuli" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Sindhupalchok" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Siraha" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Solukhumbu" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Sunsari" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Surkhet" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Syangja" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Tanahun" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Taplejung" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Tehrathum" });
            Insert.IntoTable("IssueDistrict").Row(new { Description = "Udayapur" });
        }

        public override void Down()
        {
            Delete.Table("IssueDistrict");
        }
    }
}
