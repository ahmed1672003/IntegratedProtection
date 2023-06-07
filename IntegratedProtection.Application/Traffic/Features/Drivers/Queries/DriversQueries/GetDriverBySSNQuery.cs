namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;

public record GetDriverBySSNQuery(string SSN) : IRequest<Response<GetDriverViewModel>>;
