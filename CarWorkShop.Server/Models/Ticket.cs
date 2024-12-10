using CarWorkShop.Data.Enum;
using CarWorkShop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarWorkShop.Server.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationId { get; set; }
        public string Description { get; set; }
        public string? EmployeeAssigned { get; set; }
        public StateCategory StateCategory { get; set; }
        //+= Amount * UnitPrice
        public float? TotalPrice { get; set; }
        public List <string>? TimeSlots { get; set; }
        public float? ClientPaid { get; set; }
        public bool? AcceptedOrNot { get; set; }
        public List<Part> Parts { get; set; } = new List<Part>();
    }
}
