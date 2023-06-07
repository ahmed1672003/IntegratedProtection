namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueries;
public record GetTrafficOfficerByIdQuery(int? Id) : IRequest<Response<GetTrafficOfficerViewModel>>;
