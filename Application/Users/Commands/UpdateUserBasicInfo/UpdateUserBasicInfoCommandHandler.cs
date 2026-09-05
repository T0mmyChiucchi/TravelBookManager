using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.Domain.Shared.ValueObjects;

namespace TravelBookManager.Application.Users.Commands.UpdateUserBasicInfo
{
    public sealed class UpdateUserBasicInfoCommandHandler : ICommandHandler<UpdateUserBasicInfoCommand, Guid>
    {
        private readonly IUserRepository _repo;
        public UpdateUserBasicInfoCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(UpdateUserBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.Id);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var nameResult = Name.Create(request.NewName);
            if (nameResult.IsFailure) return Result<Guid>.ValidationFailure(nameResult.Error);
            var usernameResult = Username.Create(request.NewUsername);
            if (usernameResult.IsFailure) return Result<Guid>.ValidationFailure(usernameResult.Error);
            var changeResult = userResult.Value.UpdateBasicInfo(nameResult.Value, usernameResult.Value);
            if (changeResult.IsFailure) return Result<Guid>.ValidationFailure(changeResult.Error);
            var updateResult = await _repo.UpdateAsync(userResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.Id);
        }
    }
}