using Moq;
using TravelBookManager.Application.Trips.Commands.RenameTrip;
using TravelBookManager.Domain.Trips;
using TravelBookManager.Domain.Trips.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.SharedKernel;
using Xunit;
using System.Threading.Tasks;

namespace ApplicationTests.Trips.Commands
{
    public class RenameTripCommandHandlerTests
    {
        [Fact]
        public async Task When_TripExists_RenamesTrip()
        {
            var mockRepo = new Mock<ITripRepository>();
            var trip = Trip.Create(Name.Create("Old Name").Value);
            
            mockRepo.Setup(r => r.GetByIdAsync(trip.Id)).ReturnsAsync(Result.Success(trip));
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Trip>())).ReturnsAsync(Result.Success());
            
            var handler = new RenameTripCommandHandler(mockRepo.Object);
            var command = new RenameTripCommand(trip.Id, "New Name");
            
            var result = await handler.Handle(command, default);
            
            Assert.True(result.IsSuccess);
            Assert.Equal("New Name", trip.Name.Text);
            mockRepo.Verify(r => r.UpdateAsync(trip), Times.Once);
        }
    }
}
