namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

public record PostCarCommand(PostCarViewModel ViewModel) : IRequest<Response<GetCarViewModel>>;

