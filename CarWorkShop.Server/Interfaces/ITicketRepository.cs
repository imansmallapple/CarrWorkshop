using CarWorkShop.Server.Dtos.Ticket;
using CarWorkShop.Server.Helpers;
using CarWorkShop.Server.Models;

namespace CarWorkShop.Server.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync(QueryObject query);
        Task<Ticket?> GetByIdAsync(int id); //FirstorDefault can be null
        Task<Ticket> CreateAsync(Ticket ticketModel);
        Task<Ticket?> UpdateAsync(int id, UpdateTicketRequestDto ticketDto);
        Task<Ticket?> DeleteAsync(int id);
        Task<bool> TicketExists(int id);
        Task<Ticket?> GetByBrandAsync(string brand);
        Task<Ticket?> AddTicketToUserByBrand(AppUser user, string brand);
        Task<Ticket?> RemoveTicketForUserByBrand(List<Ticket> tickets, string brand);
    }
}
