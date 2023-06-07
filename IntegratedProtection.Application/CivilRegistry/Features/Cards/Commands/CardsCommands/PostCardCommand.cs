namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

public record PostCardCommand(PostCardViewModel ViewModel) : IRequest<Response<GetCardViewModel>>;

