using GameNight.Shared.EntityClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameNight.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Logg> Loggs { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
