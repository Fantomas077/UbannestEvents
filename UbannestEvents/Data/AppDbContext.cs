using Microsoft.EntityFrameworkCore;
using UbannestEvents.Models;

namespace UbannestEvents.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
