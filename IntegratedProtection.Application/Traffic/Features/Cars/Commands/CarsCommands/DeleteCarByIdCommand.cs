namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

public record DeleteCarByIdCommand(int? Id) : IRequest<Response<GetCarViewModel>>;

