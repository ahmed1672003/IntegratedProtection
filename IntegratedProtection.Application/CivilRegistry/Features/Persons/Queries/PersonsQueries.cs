namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;

public record GetPersonByIdQuery(int? Id) : IRequest<Response<GetPersonViewModel>>;
public record GetPersonBySSNQuery(string SSN) : IRequest<Response<GetPersonViewModel>>;
public record GetAllPersonsQuery() : IRequest<Response<IEnumerable<GetPersonViewModel>>>;
public record GetPersonByIdWithCardQuery(int? PersonId) : IRequest<Response<GetPersonWithCardViewModel>>;
public record GetPersonBySSNWithCardQuery(string SSN) : IRequest<Response<GetPersonWithCardViewModel>>;




