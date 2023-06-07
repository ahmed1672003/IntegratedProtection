namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;

public record GetAllStolenCarsQuery() : IRequest<Response<IEnumerable<GetStolenCarViewModel>>>;


