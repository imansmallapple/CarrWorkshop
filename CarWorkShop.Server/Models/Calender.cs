using CarWorkShop.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWorkShop.Models
{
    [Table("Calenders")]
    public class Calender
    {
        public int Id { get; set; }
        //if time slots were occupied by certain day we set it as busy
        public string? UserName { get; set; }
        public WeekCategory? WeekCategory { get; set; }
        public FromWhenCategory? FromWhenCategory { get; set; }
        public TillWhenCategory? TillWhenCategory { get; set; }
        public int TicketId {get; set; }
    }
}
