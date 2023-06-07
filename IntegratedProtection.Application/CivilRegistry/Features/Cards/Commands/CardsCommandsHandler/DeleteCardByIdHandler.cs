using IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommandsHandler;
#region Put Card Handler

#endregion

#region Delete Card Handler
public sealed class DeleteCardByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteCardByIdCommand, Response<GetCardViewModel>>
{
    public DeleteCardByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {

    }

    public async Task<Response<GetCardViewModel>>
        Handle(DeleteCardByIdCommand request, CancellationToken cancellationToken)
    {

        if (request.Id.Equals(null))
            return BadRequest<GetCardViewModel>("id is required !");


        if (!await _context.Cards.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetCardViewModel>($"card with this id:{request.Id} not found !");

        await _context.Cards.ExecuteDeleteAsync(c => c.Id.Equals(request.Id));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }

        return Delete<GetCardViewModel>("deleted card success !");
    }
}

#endregion