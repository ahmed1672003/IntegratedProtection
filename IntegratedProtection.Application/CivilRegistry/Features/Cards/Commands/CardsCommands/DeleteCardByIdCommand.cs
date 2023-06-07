namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

public record DeleteCardByIdCommand(int? Id) : IRequest<Response<GetCardViewModel>>;

