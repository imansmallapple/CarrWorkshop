using CarWorkShop.Server.Dtos.Ticket;
using CarWorkShop.Server.Models;

namespace CarWorkShop.Server.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id); //FirstorDefault can be null
        Task<Ticket> CreateAsync(Ticket ticketModel);
        Task<Ticket?> UpdateAsync(int id, UpdateTicketRequestDto ticketDto);
        Task<Ticket?> DeleteAsync(int id);
    }
}
