namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands;

public record PostCarCommand(PostCarViewModel ViewModel) : IRequest<Response<GetCarViewModel>>;

public record PutCarCommand(PutCarViewModel ViewModel) : IRequest<Response<GetCarViewModel>>;

public record DeleteCarByIdCommand(int? Id) : IRequest<Response<GetCarViewModel>>;

public record DeleteCarByPlateCommand(string Letters, string Number) : IRequest<Response<GetCarViewModel>>;

public record DeleteAllCarsCommand() : IRequest<Response<GetCarViewModel>>;

