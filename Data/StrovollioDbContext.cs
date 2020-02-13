using Microsoft.EntityFrameworkCore;
using strovollio_api.Models;

namespace strovollio_api
{
    public class StrovollioDbContext : DbContext
    {
        public StrovollioDbContext(DbContextOptions<StrovollioDbContext> options) : base(options)
        {
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}