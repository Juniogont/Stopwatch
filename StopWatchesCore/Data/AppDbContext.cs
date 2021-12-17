using Microsoft.EntityFrameworkCore;
using StopWatchesCore.Models;

namespace StopWatchesCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Constants.ConnectionString);
        }

        public virtual DbSet<SotpWatch> SotpWatchs { get; set; }
    }
}
