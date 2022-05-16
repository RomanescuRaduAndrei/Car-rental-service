using CarRental.Models;
using Microsoft.EntityFrameworkCore;
namespace CarRental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cars> Cars { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Rents> Rents { get; set; }


    }
}
