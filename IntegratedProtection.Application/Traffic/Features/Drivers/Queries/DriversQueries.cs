namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries;

public record GetDriverByIdQuery(int? Id) : IRequest<Response<GetDriverViewModel>>;

public record GetDriverBySSNQuery(string SSN) : IRequest<Response<GetDriverViewModel>>;

public record GetAllDriversQuery() : IRequest<Response<IEnumerable<GetDriverViewModel>>>;
