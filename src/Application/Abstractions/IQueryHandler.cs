using MediatR;
using TravelBookManager.SharedKernel;

namespace TravelBookManager.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
