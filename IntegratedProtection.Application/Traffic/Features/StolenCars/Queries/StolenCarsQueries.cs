namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries;

public record GetAllStolenCarsQuery() : IRequest<Response<IEnumerable<GetStolenCarViewModel>>>;


