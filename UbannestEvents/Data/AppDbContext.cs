using Microsoft.EntityFrameworkCore;

namespace UbannestEvents.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
    }
}
