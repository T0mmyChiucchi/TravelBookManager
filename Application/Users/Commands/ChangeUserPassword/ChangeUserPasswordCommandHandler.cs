using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Commands.ChangeUserPassword
{
    public sealed class ChangeUserPasswordCommandHandler : ICommandHandler<ChangeUserPasswordCommand, Guid>
    {
        private readonly IUserRepository _repo;

        public ChangeUserPasswordCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);

            var passwordResult = Password.Create(request.NewPassword);
            if (passwordResult.IsFailure) return Result.Failure<Guid>(passwordResult.Error);

            var updateResult = userResult.Value.ChangePassword(passwordResult.Value);
            if (updateResult.IsFailure) return Result.Failure<Guid>(updateResult.Error);

            var repoUpdateResult = await _repo.UpdateAsync(userResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.UserId);
        }
    }
}
