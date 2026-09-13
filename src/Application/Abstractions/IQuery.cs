using MediatR;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Abstractions
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
