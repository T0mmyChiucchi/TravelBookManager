using Moq;
using TravelBookManager.Application.Users.Commands.ChangeUserEmail;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.SharedKernel;
using Xunit;
using System.Threading.Tasks;
using System;

namespace ApplicationTests.Users.Commands
{
    public class ChangeUserEmailCommandHandlerTests
    {
        [Fact]
        public async Task When_UserExistsAndEmailIsUnique_ChangesEmail()
        {
            var mockRepo = new Mock<IUserRepository>();
            var user = User.Create(Name.Create("Mario Rossi").Value, Email.Create("old@email.com").Value, Username.Create("mariorossi").Value, Password.Create("Pass123!").Value);
            
            mockRepo.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(Result.Success(user));
            
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<User>())).ReturnsAsync(Result.Success());
            
            var handler = new ChangeUserEmailCommandHandler(mockRepo.Object);
            var command = new ChangeUserEmailCommand(user.Id, "new@email.com");
            
            var result = await handler.Handle(command, default);
            
            Assert.True(result.IsSuccess);
            Assert.Equal("new@email.com", user.Email.Text);
            mockRepo.Verify(r => r.UpdateAsync(user), Times.Once);
        }
    }
}
