namespace CarWorkShop.Server.Dtos.Ticket
{
    public class UpdateTicketRequestDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationId { get; set; }
        public string Description { get; set; }
        public string? EmployeeAssigned { get; set; }
    }
}
