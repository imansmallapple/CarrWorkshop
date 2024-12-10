using CarWorkShop.Data.Enum;
using CarWorkShop.Server.Dtos.Part;

namespace CarWorkShop.Server.Dtos.Ticket
{
    public class TicketProfileDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationId { get; set; }
        public string Description { get; set; }
        public string? EmployeeAssigned { get; set; }
        public StateCategory StateCategory { get; set; }
        public float? TotalPrice { get; set; }
        public float? ClientPaid { get; set; }
        public bool? AcceptedOrNot { get; set; }
        public List<PartDto> Parts { get; set; }
    }
}
