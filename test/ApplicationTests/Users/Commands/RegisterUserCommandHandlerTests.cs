using Moq;
using TravelBookManager.Application.Users.Commands.RegisterUser;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;
using Xunit;
using System.Threading.Tasks;

namespace ApplicationTests.Users.Commands
{
    public class RegisterUserCommandHandlerTests
    {
        [Fact]
        public async Task When_EmailIsUnique_RegistersUser()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(Result.Success());
            
            var handler = new RegisterUserCommandHandler(mockRepo.Object);
            var command = new RegisterUserCommand("Mario Rossi", "mario@rossi.com", "mariorossi", "Pass123!");
            
            var result = await handler.Handle(command, default);
            
            Assert.True(result.IsSuccess);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
