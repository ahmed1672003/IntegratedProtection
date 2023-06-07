namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;

public record GetAllDriversQuery() : IRequest<Response<IEnumerable<GetDriverViewModel>>>;
