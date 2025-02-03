namespace eBPS.Domain.Entities.Shared
{
    public class Organizations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
