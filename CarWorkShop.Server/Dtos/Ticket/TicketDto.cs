using CarWorkShop.Data.Enum;
using CarWorkShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarWorkShop.Server.Dtos.Part;

namespace CarWorkShop.Server.Dtos.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public List<PartDto> Parts{ get; set; }
    }
}
