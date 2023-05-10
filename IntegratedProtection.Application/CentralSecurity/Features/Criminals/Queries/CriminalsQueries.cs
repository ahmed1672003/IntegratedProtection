
namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries;

public record GetCriminalByIdQuery(int? Id) : IRequest<Response<GetCriminalViewModel>>;

public record GetCriminalBySSNQuery(string SSN) : IRequest<Response<GetCriminalViewModel>>;

public record GetAllCriminalsQuery() : IRequest<Response<IEnumerable<GetCriminalViewModel>>>;


