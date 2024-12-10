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

        public bool AddAsync(Part part)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAsync(Part part)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Part>> GetAllAsync()
        {
            return await _context.Parts.ToListAsync();
        }

        public async Task<Part?> GetByIdAsync(int id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public bool SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(Part part)
        {
            throw new NotImplementedException();
        }
    }
}
