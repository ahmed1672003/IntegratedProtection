namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;
public record GetPersonBySSNWithCardQuery(string SSN) : IRequest<Response<GetPersonWithCardViewModel>>;




