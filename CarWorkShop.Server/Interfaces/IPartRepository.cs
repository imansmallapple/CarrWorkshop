using CarWorkShop.Models;

namespace CarWorkShop.Server.Interfaces
{
    public interface IPartRepository
    {
        Task<List<Part>> GetAllAsync();
        Task<Part?> GetByIdAsync(int id);
        bool AddAsync(Part part);
        bool UpdateAsync(Part part);
        bool DeleteAsync(Part part);
        bool SaveAsync();
    }
}
