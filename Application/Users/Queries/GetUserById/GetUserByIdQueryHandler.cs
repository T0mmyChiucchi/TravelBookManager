using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Dto;
using TravelBookManager.Application.Users.Mapper;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _repo;

        public GetUserByIdQueryHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetByIdAsync(request.Id);
            if (repoResult.IsFailure) return Result.Failure<UserDto>(repoResult.Error);
            return Result.Success(UserMapper.ToDto(repoResult.Value));
        }
    }
}