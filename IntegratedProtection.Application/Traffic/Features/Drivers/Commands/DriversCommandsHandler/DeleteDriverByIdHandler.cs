using IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommandsHandler;
#region Put Driver Handlers
#endregion

#region Delete Driver Handlers
public sealed class DeleteDriverByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteDriverByIdCommand, Response<GetDriverViewModel>>
{
    public DeleteDriverByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(DeleteDriverByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetDriverViewModel>("id is required !");

        if (!await _context.Drivers.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetDriverViewModel>($"driver with this id: {request.Id} not found");

        await _context.Drivers.ExecuteDeleteAsync(d => d.Id.Equals(request.Id));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }

        return Delete<GetDriverViewModel>("delete driver success !");
    }
}
#endregion