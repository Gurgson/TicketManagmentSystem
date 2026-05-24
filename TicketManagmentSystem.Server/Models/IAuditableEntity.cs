namespace TicketManagmentSystem.Server.Models
{
    public abstract class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
