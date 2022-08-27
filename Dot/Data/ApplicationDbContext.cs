using Dot.Models;
using Microsoft.EntityFrameworkCore;

namespace Dot.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }




        public DbSet<TravelTicket> Tickets { get; set; }
    }

    
}
