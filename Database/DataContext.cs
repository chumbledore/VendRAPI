using Microsoft.EntityFrameworkCore;
using Models;

namespace Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Beverage> Beverages { get; set; }
    }
}