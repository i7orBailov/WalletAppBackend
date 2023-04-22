using Microsoft.EntityFrameworkCore;

namespace WalletAppBackend.Models.Database
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Icon> Icons { get; set; }
        public DbSet<ExceptionJournal> ExceptionsJournal { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Icon>(entity =>
            {
                entity.HasKey(p => p.Id);
            });
            
            modelBuilder.Entity<ExceptionJournal>(entity =>
            {
                entity.HasKey(p => p.EventId);
            });
        }
    }
}
