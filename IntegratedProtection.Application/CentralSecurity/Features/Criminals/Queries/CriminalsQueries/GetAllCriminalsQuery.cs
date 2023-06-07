namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;

public record GetAllCriminalsQuery() : IRequest<Response<IEnumerable<GetCriminalViewModel>>>;


