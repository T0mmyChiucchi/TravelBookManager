using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users;

namespace TravelBookManager.Application.Users.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _repo;
        public RegisterUserCommandHandler(IUserRepository repo) => _repo = repo;
        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userResult = User.Create(request.Name, request.Email, request.Username, request.Password);
            if (userResult.IsFailure) return Result<Guid>.ValidationFailure(userResult.Error);
            var repoResult = await _repo.AddAsync(userResult.Value);
            return repoResult.IsFailure ? Result.Failure<Guid>(repoResult.Error) : Result.Success(userResult.Value.Id);
        }
    }
}