namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;

public record DeleteAllCriminalsCommand() : IRequest<Response<GetCriminalViewModel>>;


