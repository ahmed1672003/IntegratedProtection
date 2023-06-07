namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

public record GetPersonBySSNQuery(string SSN) : IRequest<Response<GetPersonViewModel>>;




