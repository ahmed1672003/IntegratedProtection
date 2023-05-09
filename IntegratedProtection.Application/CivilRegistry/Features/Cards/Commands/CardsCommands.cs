namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;

public record PostCardCommand(PostCardViewModel ViewModel) : IRequest<Response<GetCardViewModel>>;
public record PutCardCommand(PutCardViewModel ViewModel) : IRequest<Response<GetCardViewModel>>;
public record DeleteCardByIdCommand(int Id) : IRequest<Response<GetCardViewModel>>;
public record DeleteCardBySSNCommand(string SSN) : IRequest<Response<GetCardViewModel>>;
public record DeleteAllCardsCommand() : IRequest<Response<GetCardViewModel>>;

