using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Destinations.Dto;

namespace TravelBookManager.Application.Destinations.Queries.GetDestinationById
{
    public sealed record GetDestinationByIdQuery(Guid Id) : IQuery<DestinationDto>;
}
