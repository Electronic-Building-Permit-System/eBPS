
namespace eBPS.Domain.Entities
{
    public class LandOwner
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int Salutation { get; set; }
        public int LandOwnerType { get; set; }
        public string LandOwnerName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Tole { get; set; }
        public string CitizenshipNumber { get; set; }
        public DateTime CitizenshipIssueDate { get; set; }
        public int CitizenshipIssueDistrict { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WardNumber { get; set; }
        public string Address { get; set; }
    }
}
