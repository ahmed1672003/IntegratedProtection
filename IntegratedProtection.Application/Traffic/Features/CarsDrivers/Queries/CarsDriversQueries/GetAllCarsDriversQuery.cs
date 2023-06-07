namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Queries.CarsDriversQueries;

public record GetAllCarsDriversQuery() : IRequest<Response<IEnumerable<GetCarDriverViewModel>>>;

