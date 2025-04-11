using Microsoft.EntityFrameworkCore;
using BeverageAPI.Models;

namespace BeverageAPI.Repositories
{
    public class BeverageDbContext : DbContext
    {
        public BeverageDbContext(DbContextOptions<BeverageDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
    }
}