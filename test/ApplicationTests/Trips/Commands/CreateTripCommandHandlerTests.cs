using Moq;
using TravelBookManager.Application.Trips.Commands.CreateTrip;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.SharedKernel;

namespace ApplicationTests.Trips.Commands
{
    public class CreateTripCommandHandlerTests
    {
        [Fact]
        public async Task When_CreateTripIsCalled_AddsTripToRepository()
        {
            var mockRepo = new Mock<ITripRepository>();
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Trip>())).ReturnsAsync(Result.Success());

            var handler = new CreateTripCommandHandler(mockRepo.Object);
            var command = new CreateTripCommand(System.Guid.NewGuid(), "Roma 2025");

            var result = await handler.Handle(command, default);

            Assert.True(result.IsSuccess);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Trip>()), Times.Once);
        }
    }
}
