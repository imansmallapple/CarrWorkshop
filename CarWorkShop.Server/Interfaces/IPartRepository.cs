using CarWorkShop.Models;

namespace CarWorkShop.Server.Interfaces
{
    public interface IPartRepository
    {
        Task<List<Part>> GetAllAsync();
        Task<Part?> GetByIdAsync(int id);
        Task<Part> CreateAsync(Part partModel);
        Task<Part?> UpdateAsync(int id, Part partModel);
        Task<Part?> DeleteAsync(int id);
    }
}
