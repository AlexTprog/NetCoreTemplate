using MediatR;
using NetCoreTemplate.Domain.Abstractions;

namespace NetCoreTemplate.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> :
    IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{

}