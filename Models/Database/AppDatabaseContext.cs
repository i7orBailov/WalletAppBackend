using Microsoft.EntityFrameworkCore;

namespace WalletAppBackend.Models.Database
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Icon> Icons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public DbSet<ExceptionJournal> ExceptionsJournal { get; set; }
        
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Icon>(entity =>
            {
                entity.Property(i => i.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(u => u.PasswordHash)
                    .IsRequired();

                entity.Property(u => u.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("bytea");

                entity.HasMany(u => u.Transactions)
                    .WithOne(t => t.Owner)
                    .HasForeignKey(t => t.OwnerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(t => t.Name)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(tt => tt.Title);
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.HasIndex(ts => ts.Title)
                    .IsUnique();

                entity.Property(ts => ts.Title)
                    .IsRequired(false);
            });

            modelBuilder.Entity<ExceptionJournal>(entity =>
            {
                entity.HasKey(ej => ej.EventId);
            });
        }
    }
}
