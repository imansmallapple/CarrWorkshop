using CarWorkShop.Data.Enum;
using CarWorkShop.Models;
using System.ComponentModel.DataAnnotations;

namespace CarWorkShop.Server.Dtos.Ticket
{
    public class CreateTicketRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Brand must be 3 characters")]
        [MaxLength(20, ErrorMessage = "Brand can't be over 20 characters")]
        public string Brand { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Model must be 3 characters")]
        [MaxLength(20, ErrorMessage = "Model can't be over 20 characters")]
        public string Model { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "RegistrationId must be 3 characters")]
        [MaxLength(20, ErrorMessage = "RegistrationId can't be over 20 characters")]
        public string RegistrationId { get; set; }
        public string Description { get; set; }
        public string? EmployeeAssigned { get; set; }
    }
}
