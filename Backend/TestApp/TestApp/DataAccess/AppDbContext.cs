using Microsoft.EntityFrameworkCore;
using TestApp.Entitys;

namespace TestApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<History> History { get; set; }
    }
}
