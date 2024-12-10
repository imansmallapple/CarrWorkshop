using CarWorkShop.Models;
using CarWorkShop.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWorkShop.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Calender> Calenders { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}
