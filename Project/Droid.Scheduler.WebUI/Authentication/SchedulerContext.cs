using Droid.Scheduler.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace Droid.Scheduler.WebUI.Authentication
{
    public class SchedulerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;database=droid.scheduler;user id=droidscheduler;password=droid");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }

        public DbSet<Job> Job { get; set; }
        public DbSet<Running> Running { get; set; }
    }
}
