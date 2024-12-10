using CarWorkShop.Server.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWorkShop.Models
{
    [Table("Parts")]
    public class Part
    {
		public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Amount { get; set; }
        public float UnitPrice { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
