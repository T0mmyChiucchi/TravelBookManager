using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users.ValueObjects;

namespace TravelBookManager.Application.Users.Commands.ChangeUserPassword
{
    public sealed class ChangeUserPasswordCommandHandler : ICommandHandler<ChangeUserPasswordCommand, Guid>
    {
        private readonly IUserRepository _repo;
        public ChangeUserPasswordCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.Id);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var passwordResult = Password.Create(request.NewPassword);
            if (passwordResult.IsFailure) return Result<Guid>.ValidationFailure(passwordResult.Error);
            var changeResult = userResult.Value.ChangePassword(passwordResult.Value);
            if (changeResult.IsFailure) return Result<Guid>.ValidationFailure(changeResult.Error);
            var updateResult = await _repo.UpdateAsync(userResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.Id);
        }
    }
}