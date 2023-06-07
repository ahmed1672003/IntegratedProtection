namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;

public record DeleteCarDriverCommand(int? CarId, int? DriverId) : IRequest<Response<GetCarDriverViewModel>>;
