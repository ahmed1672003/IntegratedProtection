namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

public record GetPersonByIdWithCardQuery(int? PersonId) : IRequest<Response<GetPersonWithCardViewModel>>;




