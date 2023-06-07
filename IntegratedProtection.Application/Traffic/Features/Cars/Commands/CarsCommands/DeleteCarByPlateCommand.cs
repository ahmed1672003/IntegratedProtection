namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

public record DeleteCarByPlateCommand(string Letters, string Number) : IRequest<Response<GetCarViewModel>>;

