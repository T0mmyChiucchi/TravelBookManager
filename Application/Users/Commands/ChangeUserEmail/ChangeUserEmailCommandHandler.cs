using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Commands.ChangeUserEmail
{
    public sealed class ChangeUserEmailCommandHandler : ICommandHandler<ChangeUserEmailCommand, Guid>
    {
        private readonly IUserRepository _repo;

        public ChangeUserEmailCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.UserId);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);

            var emailResult = Email.Create(request.NewEmail);
            if (emailResult.IsFailure) return Result.Failure<Guid>(emailResult.Error);

            var updateResult = userResult.Value.ChangeEmail(emailResult.Value);
            if (updateResult.IsFailure) return Result.Failure<Guid>(updateResult.Error);

            var repoUpdateResult = await _repo.UpdateAsync(userResult.Value);
            return repoUpdateResult.IsFailure ? Result.Failure<Guid>(repoUpdateResult.Error) : Result.Success(request.UserId);
        }
    }
}
