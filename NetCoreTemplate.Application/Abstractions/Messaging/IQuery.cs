using MediatR;
using NetCoreTemplate.Domain.Abstractions;

namespace NetCoreTemplate.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}