using Microsoft.EntityFrameworkCore;
using WalletAppBackend.Models.Database;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Business
{
    public class DatabaseDataSeeder : IDatabaseSeeder
    {
        private readonly AppDatabaseContext _dbContext;

        public DatabaseDataSeeder(AppDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedDataAsync()
        {
            await _dbContext.Database.MigrateAsync();

            if (_dbContext.Users.Any() is false)
            {
                #region sampleUser1
                var sampleUser1Salt = PasswordService.GenerateSalt();
                var sampleUser1 = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    Balance = 1000,
                    PasswordSalt = sampleUser1Salt,
                    PasswordHash = PasswordService.GeneratePasswordHash("Password1", sampleUser1Salt)
                };
                #endregion

                #region sampleUser2
                var sampleUser2Salt = PasswordService.GenerateSalt();
                var sampleUser2 = new User
                {
                    FirstName = "Chris",
                    LastName = "Brown",
                    Email = "chrisbrown@example.com",
                    Balance = 800,
                    PasswordSalt = sampleUser2Salt,
                    PasswordHash = PasswordService.GeneratePasswordHash("Password2", sampleUser2Salt)
                };
                #endregion

                #region sampleUser3
                var sampleUser3Salt = PasswordService.GenerateSalt();
                var sampleUser3 = new User
                {
                    FirstName = "Kate",
                    LastName = "Taylor",
                    Email = "katetaylor@example.com",
                    Balance = 1300,
                    PasswordSalt = sampleUser3Salt,
                    PasswordHash = PasswordService.GeneratePasswordHash("Password3", sampleUser3Salt)
                };
                #endregion

                var usersList = new User[] { sampleUser1, sampleUser2, sampleUser3 };
                _dbContext.Users.AddRange(usersList);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
