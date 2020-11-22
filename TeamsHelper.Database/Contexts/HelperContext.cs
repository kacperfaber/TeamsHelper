using Microsoft.EntityFrameworkCore;

namespace TeamsHelper.Database
{
    public class HelperContext : DbContext
    {
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<User> Users { get; set; }
        
        public HelperContext()
        {
        }

        public HelperContext(DbContextOptions<HelperContext> options) : base(options)
        {
        }
    }
}