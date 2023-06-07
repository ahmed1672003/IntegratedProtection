namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommands;

public record PostCriminalCommand(PostCriminalViewModel ViewModel) : IRequest<Response<GetCriminalViewModel>>;


