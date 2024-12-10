using System.ComponentModel.DataAnnotations;

namespace CarWorkShop.Server.Dtos.Part
{
    public class UpdatePartRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Name must be 1 characters")]
        [MaxLength(20, ErrorMessage = "Name can't be over 20 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000)]
        public float Amount { get; set; }
        [Required]
        [Range(0.001, 10000)]
        public float UnitPrice { get; set; }
    }
}
