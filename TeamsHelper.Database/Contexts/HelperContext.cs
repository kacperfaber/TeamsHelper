using Microsoft.EntityFrameworkCore;

namespace TeamsHelper.Database
{
    public class HelperContext
    {
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<GoogleCalendar> GoogleCalendars { get; set; }
        public DbSet<GoogleEvent> GoogleEvents { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<TeamsEvent> TeamsEvents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}