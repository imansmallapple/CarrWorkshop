using System.ComponentModel.DataAnnotations;

namespace CarWorkShop.Server.Dtos.Part
{
    public class CreatePartDto
    {
        [Required]
        [MinLength(1, ErrorMessage ="Name must be at least 1 character")]
        [MaxLength(20, ErrorMessage ="Name can't be over 20 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1,10000)]
        public float Amount { get; set; }
        [Required]
        [Range(0.001, 10000)]
        public float UnitPrice { get; set; }
    }
}
