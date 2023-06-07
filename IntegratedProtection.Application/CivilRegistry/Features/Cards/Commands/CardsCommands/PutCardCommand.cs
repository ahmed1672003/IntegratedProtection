namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

public record PutCardCommand(PutCardViewModel ViewModel) : IRequest<Response<GetCardViewModel>>;

