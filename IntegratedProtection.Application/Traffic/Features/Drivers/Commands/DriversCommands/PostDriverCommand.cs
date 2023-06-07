namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

public record PostDriverCommand(PostDriverViewModel ViewModel) : IRequest<Response<GetDriverViewModel>>;






