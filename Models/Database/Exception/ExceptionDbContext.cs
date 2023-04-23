using Microsoft.EntityFrameworkCore;

namespace WalletAppBackend.Models.Database.Exception
{
    // dotnet ef migrations add "" --context ExceptionDbContext
    // dotnet ef database update --context ExceptionDbContext
    public class ExceptionDbContext : DbContext
    {
        public DbSet<ExceptionJournal> ExceptionsJournal { get; set; }

        public ExceptionDbContext(DbContextOptions<ExceptionDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Exception");

            modelBuilder.Entity<ExceptionJournal>(entity =>
            {
                entity.HasKey(ej => ej.EventId);
            });
        }
    }

    public interface IExceptionDbEntity { }
}
