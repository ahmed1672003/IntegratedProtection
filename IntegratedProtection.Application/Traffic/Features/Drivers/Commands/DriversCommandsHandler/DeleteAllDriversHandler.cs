using IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommandsHandler;

#region Delete Driver Handlers

public sealed class DeleteAllDriversHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllDriversCommand, Response<GetDriverViewModel>>
{
    public DeleteAllDriversHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(DeleteAllDriversCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Drivers.IsExist())
            return NoContent<GetDriverViewModel>("no drivers founded !");
        try
        {
            await _context.Drivers.ExecuteDeleteAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }
        return Delete<GetDriverViewModel>("delete driver success !");
    }
}
#endregion