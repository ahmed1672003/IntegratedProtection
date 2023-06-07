namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;
public record GetAllPersonsWithCompileQuery() : IRequest<Response<IEnumerable<GetPersonViewModel>>>;

