using CarWorkShop.Models;
using CarWorkShop.Server.Data;
using CarWorkShop.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarWorkShop.Server.Repository
{
    public class PartRepository : IPartRepository
    {
        private readonly ApplicationDBContext _context;
        public PartRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Part> CreateAsync(Part partModel)
        {
            await _context.Parts.AddAsync(partModel);
            await _context.SaveChangesAsync();
            return partModel;
        }

        public async Task<Part?> DeleteAsync(int id)
        {
            var partModel = await _context.Parts.FirstOrDefaultAsync(x => x.Id == id);
            if (partModel == null)
            {
                return null;
            }
            _context.Parts.Remove(partModel);
            await _context.SaveChangesAsync();
            return partModel;
        }

        public async Task<List<Part>> GetAllAsync()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task<Part?> GetByIdAsync(int id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public async Task<Part?> UpdateAsync(int id, Part partModel)
        {
            var existingPart = await _context.Parts.FindAsync(id);
            if (existingPart == null)
            {
                return null;
            }
            existingPart.Amount = partModel.Amount;
            existingPart.UnitPrice = partModel.UnitPrice;
            existingPart.Name = partModel.Name;

            await _context.SaveChangesAsync();
            return existingPart;
        }
    }
}
