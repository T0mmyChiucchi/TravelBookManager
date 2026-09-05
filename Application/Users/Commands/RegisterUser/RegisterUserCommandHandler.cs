using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Users.ValueObjects;

namespace TravelBookManager.Application.Users.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _repo;
        public RegisterUserCommandHandler(IUserRepository repo) => _repo = repo;
        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result<Guid>.ValidationFailure(nameResult.Error);
            var emailResult = Email.Create(request.Email);
            if (emailResult.IsFailure) return Result<Guid>.ValidationFailure(emailResult.Error);
            var usernameResult = Username.Create(request.Username);
            if (usernameResult.IsFailure) return Result<Guid>.ValidationFailure(usernameResult.Error);
            var passwordResult = Password.Create(request.Password);
            if (passwordResult.IsFailure) return Result<Guid>.ValidationFailure(passwordResult.Error);
            var userResult = User.Create(nameResult.Value, emailResult.Value, usernameResult.Value, passwordResult.Value);
            var repoResult = await _repo.AddAsync(userResult.Value);
            return repoResult.IsFailure ? Result.Failure<Guid>(repoResult.Error) : Result.Success(userResult.Value.Id);
        }
    }
}