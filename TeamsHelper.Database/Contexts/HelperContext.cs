using Microsoft.EntityFrameworkCore;

namespace TeamsHelper.Database
{
    public class HelperContext : DbContext
    {
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Synchronization> Synchronizations { get; set; }
        public DbSet<SynchronizedEvent> Events { get; set; }
        public DbSet<DailyRaport> Raports { get; set; }
        
        public HelperContext()
        {
        }

        public HelperContext(DbContextOptions<HelperContext> options) : base(options)
        {
        }
    }
}