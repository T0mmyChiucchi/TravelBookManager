using TravelBookManager.Application.Abstractions;
using TravelBookManager.SharedKernel;
using TravelBookManager.Domain.Users.Repositories;

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
            var changeResult = userResult.Value.UpdateBasicInfo(request.NewName, request.NewUsername);
            if (changeResult.IsFailure) return Result<Guid>.ValidationFailure(changeResult.Error);
            var updateResult = await _repo.UpdateAsync(userResult.Value);
            return updateResult.IsFailure ? Result.Failure<Guid>(updateResult.Error) : Result.Success(request.Id);
        }
    }
}