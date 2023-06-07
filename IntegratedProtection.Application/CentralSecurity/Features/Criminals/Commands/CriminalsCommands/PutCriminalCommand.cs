namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;

public record PutCriminalCommand(PutCriminalViewModel ViewModel) : IRequest<Response<GetCriminalViewModel>>;


