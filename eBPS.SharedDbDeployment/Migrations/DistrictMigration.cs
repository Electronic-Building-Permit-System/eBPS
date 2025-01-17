using FluentMigrator;

namespace eBPS.SharedDbDeployment.Migrations
{
    [Migration(202501080547)]
    public class CreateDistrictTable : Migration
    {
        public override void Up()
        {
            Create.Table("District")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Description").AsString(100).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(true);

            // Insert all districts one by one
            Insert.IntoTable("District").Row(new { Description = "Achham" });
            Insert.IntoTable("District").Row(new { Description = "Arghakhanchi" });
            Insert.IntoTable("District").Row(new { Description = "Baglung" });
            Insert.IntoTable("District").Row(new { Description = "Baitadi" });
            Insert.IntoTable("District").Row(new { Description = "Bajhang" });
            Insert.IntoTable("District").Row(new { Description = "Bajura" });
            Insert.IntoTable("District").Row(new { Description = "Banke" });
            Insert.IntoTable("District").Row(new { Description = "Bara" });
            Insert.IntoTable("District").Row(new { Description = "Bardiya" });
            Insert.IntoTable("District").Row(new { Description = "Bhaktapur" });
            Insert.IntoTable("District").Row(new { Description = "Bhojpur" });
            Insert.IntoTable("District").Row(new { Description = "Chitwan" });
            Insert.IntoTable("District").Row(new { Description = "Dadeldhura" });
            Insert.IntoTable("District").Row(new { Description = "Dailekh" });
            Insert.IntoTable("District").Row(new { Description = "Dang" });
            Insert.IntoTable("District").Row(new { Description = "Darchula" });
            Insert.IntoTable("District").Row(new { Description = "Dhading" });
            Insert.IntoTable("District").Row(new { Description = "Dhankuta" });
            Insert.IntoTable("District").Row(new { Description = "Dhanusha" });
            Insert.IntoTable("District").Row(new { Description = "Dolakha" });
            Insert.IntoTable("District").Row(new { Description = "Dolpa" });
            Insert.IntoTable("District").Row(new { Description = "Doti" });
            Insert.IntoTable("District").Row(new { Description = "Gorkha" });
            Insert.IntoTable("District").Row(new { Description = "Gulmi" });
            Insert.IntoTable("District").Row(new { Description = "Humla" });
            Insert.IntoTable("District").Row(new { Description = "Ilam" });
            Insert.IntoTable("District").Row(new { Description = "Jajarkot" });
            Insert.IntoTable("District").Row(new { Description = "Jhapa" });
            Insert.IntoTable("District").Row(new { Description = "Jumla" });
            Insert.IntoTable("District").Row(new { Description = "Kailali" });
            Insert.IntoTable("District").Row(new { Description = "Kalikot" });
            Insert.IntoTable("District").Row(new { Description = "Kanchanpur" });
            Insert.IntoTable("District").Row(new { Description = "Kapilvastu" });
            Insert.IntoTable("District").Row(new { Description = "Kaski" });
            Insert.IntoTable("District").Row(new { Description = "Kathmandu" });
            Insert.IntoTable("District").Row(new { Description = "Kavrepalanchok" });
            Insert.IntoTable("District").Row(new { Description = "Khotang" });
            Insert.IntoTable("District").Row(new { Description = "Lalitpur" });
            Insert.IntoTable("District").Row(new { Description = "Lamjung" });
            Insert.IntoTable("District").Row(new { Description = "Mahottari" });
            Insert.IntoTable("District").Row(new { Description = "Makwanpur" });
            Insert.IntoTable("District").Row(new { Description = "Manang" });
            Insert.IntoTable("District").Row(new { Description = "Morang" });
            Insert.IntoTable("District").Row(new { Description = "Mugu" });
            Insert.IntoTable("District").Row(new { Description = "Mustang" });
            Insert.IntoTable("District").Row(new { Description = "Myagdi" });
            Insert.IntoTable("District").Row(new { Description = "Nawalparasi (Bardaghat Susta East)" });
            Insert.IntoTable("District").Row(new { Description = "Nawalparasi (Bardaghat Susta West)" });
            Insert.IntoTable("District").Row(new { Description = "Nuwakot" });
            Insert.IntoTable("District").Row(new { Description = "Okhaldhunga" });
            Insert.IntoTable("District").Row(new { Description = "Palpa" });
            Insert.IntoTable("District").Row(new { Description = "Panchthar" });
            Insert.IntoTable("District").Row(new { Description = "Parbat" });
            Insert.IntoTable("District").Row(new { Description = "Parsa" });
            Insert.IntoTable("District").Row(new { Description = "Pyuthan" });
            Insert.IntoTable("District").Row(new { Description = "Ramechhap" });
            Insert.IntoTable("District").Row(new { Description = "Rasuwa" });
            Insert.IntoTable("District").Row(new { Description = "Rautahat" });
            Insert.IntoTable("District").Row(new { Description = "Rolpa" });
            Insert.IntoTable("District").Row(new { Description = "Rukum East" });
            Insert.IntoTable("District").Row(new { Description = "Rukum West" });
            Insert.IntoTable("District").Row(new { Description = "Rupandehi" });
            Insert.IntoTable("District").Row(new { Description = "Salyan" });
            Insert.IntoTable("District").Row(new { Description = "Sankhuwasabha" });
            Insert.IntoTable("District").Row(new { Description = "Saptari" });
            Insert.IntoTable("District").Row(new { Description = "Sarlahi" });
            Insert.IntoTable("District").Row(new { Description = "Sindhuli" });
            Insert.IntoTable("District").Row(new { Description = "Sindhupalchok" });
            Insert.IntoTable("District").Row(new { Description = "Siraha" });
            Insert.IntoTable("District").Row(new { Description = "Solukhumbu" });
            Insert.IntoTable("District").Row(new { Description = "Sunsari" });
            Insert.IntoTable("District").Row(new { Description = "Surkhet" });
            Insert.IntoTable("District").Row(new { Description = "Syangja" });
            Insert.IntoTable("District").Row(new { Description = "Tanahun" });
            Insert.IntoTable("District").Row(new { Description = "Taplejung" });
            Insert.IntoTable("District").Row(new { Description = "Tehrathum" });
            Insert.IntoTable("District").Row(new { Description = "Udayapur" });
        }

        public override void Down()
        {
            Delete.Table("District");
        }
    }
}
