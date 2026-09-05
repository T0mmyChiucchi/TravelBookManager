using TravelBookManager.Application.Abstractions;
using TravelBookManager.Application.Users.Dto;
using TravelBookManager.Application.Users.Mapper;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Queries.GetUserByUsername
{
    public sealed class GetUserByUsernameQueryHandler : IQueryHandler<GetUserByUsernameQuery, UserDto>
    {
        private readonly IUserRepository _repo;

        public GetUserByUsernameQueryHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<UserDto>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var repoResult = await _repo.GetByUsernameAsync(request.Username);
            if (repoResult.IsFailure) return Result.Failure<UserDto>(repoResult.Error);
            return Result.Success(UserMapper.ToDto(repoResult.Value));
        }
    }
}