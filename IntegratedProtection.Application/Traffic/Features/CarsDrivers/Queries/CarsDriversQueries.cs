namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Queries;

public record GetAllCarsDriversQuery() : IRequest<Response<IEnumerable<GetCarDriverViewModel>>>;

