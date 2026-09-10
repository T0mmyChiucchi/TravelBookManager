using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Flights.Dto;
using TravelBookManager.Application.Flights.Mapper;
using TravelBookManager.Domain.Flights.Repositories;
using TravelBookManager.SharedKernel;
using System.Linq;

namespace TravelBookManager.Application.Flights.Queries.GetAllFlights
{
    public sealed class GetAllFlightsQueryHandler : IQueryHandler<GetAllFlightsQuery, List<FlightDto>>
    {
        private readonly IFlightRepository _repo;

        public GetAllFlightsQueryHandler(IFlightRepository repo) => _repo = repo;

        public async Task<Result<List<FlightDto>>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetAllAsync();
            if (repoResult.IsFailure) return Result.Failure<List<FlightDto>>(repoResult.Error);
            var dtos = repoResult.Value.Select(e => e.ToDto()).ToList();
            return Result.Success(dtos);
        }
    }
}
