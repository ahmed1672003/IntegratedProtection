namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommandsHandler;

public sealed class DeleteCriminalByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteCriminalByIdCommand, Response<GetCriminalViewModel>>
{
    public DeleteCriminalByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(DeleteCriminalByIdCommand request, CancellationToken cancellationToken)
    {

        if (request.Id.Equals(null))
            return BadRequest<GetCriminalViewModel>("Id is required !");

        if (!await _context.Criminals.IsExist(e => e.Id.Equals(request.Id)))
            return NotFound<GetCriminalViewModel>($"this criminal with this Id:{request.Id} not found !");
        await _context.Criminals.ExecuteDeleteAsync(e => e.Id.Equals(request.Id));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }
        return Delete<GetCriminalViewModel>("deleted success !");
    }
}
