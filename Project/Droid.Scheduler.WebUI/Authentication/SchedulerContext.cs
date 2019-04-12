using Microsoft.EntityFrameworkCore;

namespace Droid.Scheduler.WebUI.Authentication
{
    public class SchedulerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;database=droid.scheduler;user id=droidscheduler;password=droid");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ppartobid01");
        }
    }
}
