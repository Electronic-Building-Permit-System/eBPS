
namespace eBPS.Domain.Entities
{
    public class HouseOwner
    {
        public int Id { get; set; } 
        public int ApplicationId { get; set; } 
        public int Salutation { get; set; } 
        public int HouseOwnerType { get; set; } 
        public string HouseOwnerName { get; set; } 
        // public string HouseOwnerPhotoPath { get; set; } // Path to House Owner's Photo
        public string FatherName { get; set; } 
        public string GrandFatherName { get; set; } 
        public string Tole { get; set; } 
        public string CitizenshipNumber { get; set; } 
        public DateTime CitizenshipIssueDate { get; set; } 
        public DateTime CitizenshipIssueDistrict { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WardNumber { get; set; } 
        public string Address { get; set; } 

    }
}
