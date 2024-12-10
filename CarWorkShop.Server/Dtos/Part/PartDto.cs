
namespace CarWorkShop.Server.Dtos.Part
{
    public class PartDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Amount { get; set; }
        public float UnitPrice { get; set; }
        public int TicketId { get; set; }
    }
}
