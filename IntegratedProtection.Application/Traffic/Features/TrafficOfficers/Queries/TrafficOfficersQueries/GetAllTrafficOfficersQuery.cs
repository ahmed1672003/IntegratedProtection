namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueries;

public record GetAllTrafficOfficersQuery() : IRequest<Response<IEnumerable<GetTrafficOfficerViewModel>>>;
