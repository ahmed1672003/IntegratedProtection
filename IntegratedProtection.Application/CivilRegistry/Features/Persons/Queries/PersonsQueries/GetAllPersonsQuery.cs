namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

public record GetAllPersonsQuery() : IRequest<Response<IEnumerable<GetPersonViewModel>>>;




