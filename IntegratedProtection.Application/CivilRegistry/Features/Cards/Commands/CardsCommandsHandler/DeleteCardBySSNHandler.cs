using IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommandsHandler;

#region Delete Card Handler

public sealed class DeleteCardBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeleteCardBySSNCommand, Response<GetCardViewModel>>
{
    public DeleteCardBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(DeleteCardBySSNCommand request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetCardViewModel>("SSN is required !");

        if (!await _context.Cards.IsExist(c => c.SSN.Equals(request.SSN)))
            return NotFound<GetCardViewModel>($"card with this SSN:{request.SSN} not found !");

        await _context.Cards.ExecuteDeleteAsync(c => c.Id.Equals(request.SSN));
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