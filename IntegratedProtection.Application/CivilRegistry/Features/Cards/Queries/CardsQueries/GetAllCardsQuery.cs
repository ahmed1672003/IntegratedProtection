namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

public record GetAllCardsQuery : IRequest<Response<IEnumerable<GetCardViewModel>>>;



