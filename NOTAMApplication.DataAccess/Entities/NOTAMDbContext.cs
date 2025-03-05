using Microsoft.EntityFrameworkCore;

namespace NOTAMApplication.DataAccess.Entities;

public class NOTAMDbContext : DbContext
{
    public DbSet<CrawlJob> CrawlJobs { get; set; }
    public DbSet<NOTAM> NOTAMs { get; set; }

    public NOTAMDbContext(DbContextOptions<NOTAMDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NOTAM>()
            .HasOne<CrawlJob>()
            .WithMany()
            .HasForeignKey(c => c.JobId);
    }
}
