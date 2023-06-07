namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;

public record DeleteCriminalByIdCommand(int? Id) : IRequest<Response<GetCriminalViewModel>>;


