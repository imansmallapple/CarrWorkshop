using CarWorkShop.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWorkShop.Models
{
    [Table("Estimates")]
    public class RepairEstimate
    {
        public int Id { get; set; }
        public string? Description {  get; set; }
        public float? cost { get; set; }
        public AttitudeCategory AttitudeCategory { get; set; }
    }
}
