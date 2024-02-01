using Microsoft.EntityFrameworkCore;

namespace SMS.WebApp.DatabaseContest
{
    public class ApplicationDbContest(DbContextOptions<ApplicationDbContest> contextOptions) : DbContext(contextOptions)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContest).Assembly);
        }
    }

}
