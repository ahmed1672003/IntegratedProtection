namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

public record GetPersonByIdQuery(int? Id) : IRequest<Response<GetPersonViewModel>>;




