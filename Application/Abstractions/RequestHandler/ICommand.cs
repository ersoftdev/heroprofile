using MediatR;

namespace Hero.Application.Abstractions.RequestHandler;

public interface ICommand : IRequest<Result> {}

public interface ICommand<TResponse> : IRequest<Result<TResponse>> {}

