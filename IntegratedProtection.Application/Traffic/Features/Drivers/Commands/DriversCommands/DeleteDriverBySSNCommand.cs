namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

public record DeleteDriverBySSNCommand(string SSN) : IRequest<Response<GetDriverViewModel>>;






