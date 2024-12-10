using CarWorkShop.Server.Models;

namespace CarWorkShop.Server.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Ticket>> GetUserTickets(AppUser user);
    }
}
