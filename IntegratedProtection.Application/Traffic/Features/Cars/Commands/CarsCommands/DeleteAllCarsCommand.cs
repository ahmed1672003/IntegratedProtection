namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

public record DeleteAllCarsCommand() : IRequest<Response<GetCarViewModel>>;

