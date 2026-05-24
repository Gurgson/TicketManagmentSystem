namespace TicketManagmentSystem.Server.Models
{
    public class Location : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public int GridWidth { get; set; }
        public int GridHeight { get; set; }


    }
}
