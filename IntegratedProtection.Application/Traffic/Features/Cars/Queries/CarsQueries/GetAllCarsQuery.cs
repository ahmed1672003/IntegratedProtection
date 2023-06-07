namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

public record GetAllCarsQuery() : IRequest<Response<IEnumerable<GetCarViewModel>>>;

