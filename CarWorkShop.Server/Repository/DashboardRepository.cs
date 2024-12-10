using CarWorkShop.Server.Data;
using CarWorkShop.Server.Interfaces;
using CarWorkShop.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWorkShop.Server.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDBContext _context;

        public DashboardRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetUserTickets(AppUser user)
        {
            return await _context.Tickets.Where(t => t.AppUserId == user.Id)
                .ToListAsync();
        }
    }
}
