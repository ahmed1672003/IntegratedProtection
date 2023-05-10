namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands;

public record PostCarDriverCommand(PostCarDriverViewModel ViewModel) : IRequest<Response<GetCarDriverViewModel>>;


public record DeleteCarDriverCommand(int? CarId, int? DriverId) : IRequest<Response<GetCarDriverViewModel>>;

public record DeleteAllCarsDriversCommand() : IRequest<Response<GetCarDriverViewModel>>;
