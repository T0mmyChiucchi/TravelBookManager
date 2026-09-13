using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;

namespace TravelBookManager.Application.Users.Commands.RemoveUser
{
    public sealed class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand, Guid>
    {
        private readonly IUserRepository _repo;
        public RemoveUserCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var removeResult = await _repo.RemoveAsync(request.Id);
            return removeResult.IsFailure ? Result.Failure<Guid>(removeResult.Error) : Result.Success(request.Id);
        }
    }
}