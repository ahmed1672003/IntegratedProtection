namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommandsHandler;

public sealed class DeleteCriminalBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeleteCriminalBySSNCommand, Response<GetCriminalViewModel>>
{
    public DeleteCriminalBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(DeleteCriminalBySSNCommand request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetCriminalViewModel>("SSN is required !");

        if (!await _context.Criminals.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetCriminalViewModel>($"criminal with this SSN: {request.SSN} not found !");

        await _context.Criminals.ExecuteDeleteAsync(e => e.SSN.Equals(request.SSN));

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
