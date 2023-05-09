namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries;

public record GetAllTrafficOfficersQuery() : IRequest<Response<IEnumerable<GetTrafficOfficerViewModel>>>;
public record GetTrafficOfficerByIdQuery(int? Id) : IRequest<Response<GetTrafficOfficerViewModel>>;
