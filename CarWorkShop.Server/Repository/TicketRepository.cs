using CarWorkShop.Server.Data;
using CarWorkShop.Server.Dtos.Ticket;
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

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.Include(c=>c.Parts).ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.Include(c => c.Parts).FirstOrDefaultAsync(i =>i.Id == id);
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

            await _context.SaveChangesAsync();
            return existingTicket;
        }
    }
}
