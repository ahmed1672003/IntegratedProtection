using IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommandsHandler;

public sealed class DeleteAllCardsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCardsCommand, Response<GetCardViewModel>>
{
    public DeleteAllCardsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(DeleteAllCardsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cards.IsExist())
            return NotFound<GetCardViewModel>("no cards found !");

        await _context.Cards.ExecuteDeleteAsync();

        return Delete<GetCardViewModel>("deleted all cards success !");
    }
}

#endregion