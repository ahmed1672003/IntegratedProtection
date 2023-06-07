namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

public record PutDriverCommand(PutDriverViewModel ViewModel) : IRequest<Response<GetDriverViewModel>>;






