namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;

public record DeleteCriminalBySSNCommand(string SSN) : IRequest<Response<GetCriminalViewModel>>;


