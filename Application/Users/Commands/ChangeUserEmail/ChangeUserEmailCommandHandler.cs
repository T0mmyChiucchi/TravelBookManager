using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users.ValueObjects;

namespace TravelBookManager.Application.Users.Commands.ChangeUserEmail
{
    public sealed class ChangeUserEmailCommandHandler : ICommandHandler<ChangeUserEmailCommand, Guid>
    {
        private readonly IUserRepository _repo;
        public ChangeUserEmailCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
        {
            var userResult = await _repo.GetByIdAsync(request.Id);
            if (userResult.IsFailure) return Result.Failure<Guid>(userResult.Error);
            var emailResult = Email.Create(request.NewEmail);
            if (emailResult.IsFailure) return Result<Guid>.ValidationFailure(emailResult.Error);
            var changeResult = userResult.Value.ChangeEmail(emailResult.Value);
            if (changeResult.IsFailure) return Result<Guid>.ValidationFailure(changeResult.Error);
            var updateResult = await _repo.UpdateAsync(userResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.Id);
        }
    }
}