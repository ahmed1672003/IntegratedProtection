namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;

public record DeleteAllCarsDriversCommand() : IRequest<Response<GetCarDriverViewModel>>;
