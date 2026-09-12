using TravelBookManager.Application.Abstractions;
using TravelBookManager.Domain.Users;
using TravelBookManager.Domain.Users.Repositories;
using TravelBookManager.Domain.Shared.ValueObjects;
using TravelBookManager.Domain.Users.ValueObjects;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Users.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _repo;

        public RegisterUserCommandHandler(IUserRepository repo) => _repo = repo;

        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var nameResult = Name.Create(request.Name);
            if (nameResult.IsFailure) return Result.Failure<Guid>(nameResult.Error);

            var emailResult = Email.Create(request.Email);
            if (emailResult.IsFailure) return Result.Failure<Guid>(emailResult.Error);

            var usernameResult = Username.Create(request.Username);
            if (usernameResult.IsFailure) return Result.Failure<Guid>(usernameResult.Error);

            var passwordResult = Password.Create(request.Password);
            if (passwordResult.IsFailure) return Result.Failure<Guid>(passwordResult.Error);

            var user = User.Create(nameResult.Value, emailResult.Value, usernameResult.Value, passwordResult.Value);
            var addResult = await _repo.AddAsync(user);
            return addResult.IsFailure ? Result.Failure<Guid>(addResult.Error) : Result.Success(user.Id);
        }
    }
}
