using CarWorkShop.Server.Data;
using CarWorkShop.Server.Dtos.Ticket;
using CarWorkShop.Server.Helpers;
using CarWorkShop.Server.Interfaces;
using CarWorkShop.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWorkShop.Server.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext _context;
        public TicketRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateAsync(Ticket ticketModel)
        {
            await _context.Tickets.AddAsync(ticketModel);
            await _context.SaveChangesAsync();
            return ticketModel;
        }

        public async Task<Ticket?> DeleteAsync(int id)
        {
            var ticketModel = await _context.Tickets.FirstOrDefaultAsync(x=>x.Id== id);
            if (ticketModel==null)
            {
                return null;
            }
            _context.Tickets.Remove(ticketModel);
            await _context.SaveChangesAsync();
            return ticketModel;
        }

        public async Task<List<Ticket>> GetAllAsync(QueryObject query)
        {
            var tickets = _context.Tickets.Include(c => c.Parts).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Brand))
            {
                tickets=tickets.Where(s=>s.Brand.Contains(query.Brand));
            }
            if (!string.IsNullOrWhiteSpace(query.EmployeeAssigned))
            {
                tickets = tickets.Where(s=>s.EmployeeAssigned.Contains(query.EmployeeAssigned));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Brand", StringComparison.OrdinalIgnoreCase))
                {
                    tickets = query.IsDecsending ? tickets.OrderByDescending(s=>s.Brand): tickets.OrderBy(s=>s.Brand);
                }
            }

            var skipNumber = (query.PageNumber -1) * query.PageSize;
            return await tickets.Skip(skipNumber).Take((query.PageSize)).ToListAsync();
        }

        public async Task<Ticket?> GetByBrandAsync(string brand)
        {
            return await _context.Tickets.FirstOrDefaultAsync(s=>s.Brand == brand);
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.Include(c => c.Parts).FirstOrDefaultAsync(i =>i.Id == id);
        }

        public Task<bool> TicketExists(int id)
        {
            return _context.Tickets.AnyAsync(s => s.Id == id);
        }

        public async Task<Ticket?> UpdateAsync(int id, UpdateTicketRequestDto ticketDto)
        {
            var existingTicket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTicket == null)
            {
                return null;
            }
            existingTicket.Brand = ticketDto.Brand;
            existingTicket.Model = ticketDto.Model;
            existingTicket.RegistrationId = ticketDto.RegistrationId;
            existingTicket.Description = ticketDto.Description;
            existingTicket.EmployeeAssigned = ticketDto.EmployeeAssigned;
            existingTicket.StateCategory = ticketDto.StateCategory;
            await _context.SaveChangesAsync();
            return existingTicket;
        }
        public async Task<Ticket?> AddTicketToUserByBrand(AppUser user, string brand)
        {
            var existingTicket = await _context.Tickets.FirstOrDefaultAsync(t=>t.Brand==brand);
            if (existingTicket == null)
            {
                return null;
            }
            existingTicket.AppUserId = user.Id;
            await _context.SaveChangesAsync();
            return existingTicket;
        }

        public async Task<Ticket?> RemoveTicketForUserByBrand(List<Ticket> userTickets, string brand)
        {
           var ticket = userTickets.FirstOrDefault(t => t.Brand == brand);
            if (ticket == null)
            {
                return null;
            }
            ticket.AppUserId = null;
            await _context.SaveChangesAsync();
            return ticket;
        }
    }
}
