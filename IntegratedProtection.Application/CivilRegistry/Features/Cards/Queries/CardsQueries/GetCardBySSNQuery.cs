namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

public record GetCardBySSNQuery(string SSN) : IRequest<Response<GetCardViewModel>>;



