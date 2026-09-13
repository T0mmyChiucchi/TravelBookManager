using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Commands.UpdateUserBasicInfo
{
    public sealed class UpdateUserBasicInfoCommandHandler : ICommandHandler<UpdateUserBasicInfoCommand, Guid>
    {
        private readonly IUserRepository _repo;

        public UpdateUserBasicInfoCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(UpdateUserBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);

            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            var usernameResult = Username.Create(request.Username);
            if (usernameResult.IsFailure) return Result.Failure<Guid>(usernameResult.Error);

            var updateResult = userResult.Value.UpdateBasicInfo(nameResult.Value, usernameResult.Value);
            if (updateResult.IsFailure) return Result.Failure<Guid>(updateResult.Error);

            var repoUpdateResult = await _repo.UpdateAsync(userResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.UserId);
        }
    }
}
