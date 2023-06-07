namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

public record PutCarCommand(PutCarViewModel ViewModel) : IRequest<Response<GetCarViewModel>>;

