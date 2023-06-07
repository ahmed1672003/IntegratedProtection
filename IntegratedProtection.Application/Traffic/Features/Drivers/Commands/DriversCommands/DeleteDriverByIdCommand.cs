namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

public record DeleteDriverByIdCommand(int? Id) : IRequest<Response<GetDriverViewModel>>;






