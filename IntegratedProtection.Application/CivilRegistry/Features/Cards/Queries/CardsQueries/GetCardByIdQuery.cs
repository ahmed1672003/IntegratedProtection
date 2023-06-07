namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

public record GetCardByIdQuery(int? Id) : IRequest<Response<GetCardViewModel>>;



