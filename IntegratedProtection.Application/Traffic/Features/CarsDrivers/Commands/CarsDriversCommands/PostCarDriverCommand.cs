namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;

public record PostCarDriverCommand(PostCarDriverViewModel ViewModel) : IRequest<Response<GetCarDriverViewModel>>;
