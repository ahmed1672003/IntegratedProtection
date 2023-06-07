namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;
public record GetCardBySSNWithPersonQuery(string SSN) : IRequest<Response<GetPersonWithCardViewModel>>;



