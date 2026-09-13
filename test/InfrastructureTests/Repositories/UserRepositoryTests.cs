using Microsoft.EntityFrameworkCore;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Infrastructure.Database;
using TravelBookManager.Infrastructure.Database.Repositories;

namespace InfrastructureTests.Repositories
{
    public class UserRepositoryTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async System.Threading.Tasks.Task When_AddUser_CanBeRetrieved()
        {
            var context = GetDbContext();
            var repo = new UserRepository(context);

            var name = Name.Create("Mario Rossi").Value;
            var email = Email.Create("mario@rossi.com").Value;
            var username = Username.Create("mariorossi").Value;
            var password = Password.Create("Pass123!").Value;

            var user = User.Create(name, email, username, password);

            await repo.AddAsync(user);

            var retrievedResult = await repo.GetByIdAsync(user.Id);
            Assert.True(retrievedResult.IsSuccess);
            Assert.Equal("mario@rossi.com", retrievedResult.Value.Email.Text);
        }
    }
}
