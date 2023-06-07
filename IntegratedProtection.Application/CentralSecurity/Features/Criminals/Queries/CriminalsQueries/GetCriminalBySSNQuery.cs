namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;

public record GetCriminalBySSNQuery(string SSN) : IRequest<Response<GetCriminalViewModel>>;


