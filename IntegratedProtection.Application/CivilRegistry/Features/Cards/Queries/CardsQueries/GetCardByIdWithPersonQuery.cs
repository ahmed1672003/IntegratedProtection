namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

public record GetCardByIdWithPersonQuery(int? Id) : IRequest<Response<GetPersonWithCardViewModel>>;



