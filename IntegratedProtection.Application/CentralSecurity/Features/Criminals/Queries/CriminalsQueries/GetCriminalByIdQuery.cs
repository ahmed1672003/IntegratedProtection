namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;

public record GetCriminalByIdQuery(int? Id) : IRequest<Response<GetCriminalViewModel>>;


