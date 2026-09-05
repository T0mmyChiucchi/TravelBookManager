using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Dto;
using TravelBookManager.Application.Users.Mapper;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Queries.GetUserByEmail
{
    public sealed class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IUserRepository _repo;

        public GetUserByEmailQueryHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetByEmailAsync(request.Email);
            if (repoResult.IsFailure) return Result.Failure<UserDto>(repoResult.Error);
            return Result.Success(UserMapper.ToDto(repoResult.Value));
        }
    }
}