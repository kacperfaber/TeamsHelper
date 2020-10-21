using Microsoft.EntityFrameworkCore;

namespace TeamsHelper.Database
{
    public class HelperContext : DbContext
    {
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<GoogleCalendar> GoogleCalendars { get; set; }
        public DbSet<GoogleEvent> GoogleEvents { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<TeamsEvent> TeamsEvents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Event> Events { get; set; }

        public HelperContext()
        {
        }

        public HelperContext(DbContextOptions<HelperContext> options) : base(options)
        {
        }
    }
}