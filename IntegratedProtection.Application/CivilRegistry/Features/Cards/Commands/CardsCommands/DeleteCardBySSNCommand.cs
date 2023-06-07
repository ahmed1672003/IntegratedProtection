namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

public record DeleteCardBySSNCommand(string SSN) : IRequest<Response<GetCardViewModel>>;

