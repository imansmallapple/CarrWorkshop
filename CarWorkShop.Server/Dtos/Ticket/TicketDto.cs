using CarWorkShop.Data.Enum;
using CarWorkShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarWorkShop.Server.Dtos.Part;
using CarWorkShop.Server.Models;

namespace CarWorkShop.Server.Dtos.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public List<PartDto> Parts{ get; set; }
        public string RegistrationId { get; set; }
        public string? EmployeeAssigned { get; set; }
        public StateCategory StateCategory { get; set; }
        //+= Amount * UnitPrice
        public float? TotalPrice { get; set; }
        public List<string>? TimeSlots { get; set; }
        public float? ClientPaid { get; set; }
        public bool? AcceptedOrNot { get; set; }
        public string? AppUserId { get; set; }
    }
}
