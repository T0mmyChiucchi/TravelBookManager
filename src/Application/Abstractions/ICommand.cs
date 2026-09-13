using MediatR;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Abstractions
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}