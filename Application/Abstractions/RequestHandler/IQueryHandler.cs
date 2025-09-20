using MediatR;

namespace Hero.Application.Abstractions.RequestHandler;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> {}