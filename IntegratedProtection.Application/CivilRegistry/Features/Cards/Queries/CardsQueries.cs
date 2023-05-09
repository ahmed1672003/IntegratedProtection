namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;

public record GetAllCardsQuery : IRequest<Response<IEnumerable<GetCardViewModel>>>;
public record GetCardByIdQuery(int? Id) : IRequest<Response<GetCardViewModel>>;
public record GetCardBySSNQuery(string SSN) : IRequest<Response<GetCardViewModel>>;
public record GetCardByIdWithPersonQuery(int? Id) : IRequest<Response<GetPersonWithCardViewModel>>;
public record GetCardBySSNWithPersonQuery(string SSN) : IRequest<Response<GetPersonWithCardViewModel>>;



