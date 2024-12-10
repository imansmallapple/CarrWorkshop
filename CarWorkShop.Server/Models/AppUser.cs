using Microsoft.AspNetCore.Identity;

namespace CarWorkShop.Server.Models
{
    public class AppUser: IdentityUser
    {
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
