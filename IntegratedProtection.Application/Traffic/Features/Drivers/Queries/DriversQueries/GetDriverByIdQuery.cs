namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;

public record GetDriverByIdQuery(int? Id) : IRequest<Response<GetDriverViewModel>>;
