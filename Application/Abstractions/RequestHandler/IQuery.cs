using MediatR;

namespace Hero.Application.Abstractions.RequestHandler;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}