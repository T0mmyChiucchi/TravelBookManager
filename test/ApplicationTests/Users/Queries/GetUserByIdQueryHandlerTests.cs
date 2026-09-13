using Moq;
using TravelBookManager.Application.Users.Queries.GetUserById;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.SharedKernel;
using Xunit;
using System.Threading.Tasks;

namespace ApplicationTests.Users.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task When_UserExists_ReturnsUserDto()
        {
            var mockRepo = new Mock<IUserRepository>();
            var user = User.Create(Name.Create("Mario").Value, Email.Create("m@m.com").Value, Username.Create("mario").Value, Password.Create("Pass123!").Value);
            
            mockRepo.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(Result.Success(user));
            
            var handler = new GetUserByIdQueryHandler(mockRepo.Object);
            var query = new GetUserByIdQuery(user.Id);
            
            var result = await handler.Handle(query, default);
            
            Assert.True(result.IsSuccess);
            Assert.Equal("Mario", result.Value.Name);
            Assert.Equal("m@m.com", result.Value.Email);
        }
    }
}
