using MediatR;
using NetCoreTemplate.Domain.Abstractions;

namespace NetCoreTemplate.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { }

public interface IBaseCommand { }