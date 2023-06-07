using IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommandsHandler;
#region Delete Driver Handlers

public sealed class DeleteDriverBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeleteDriverBySSNCommand, Response<GetDriverViewModel>>
{
    public DeleteDriverBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(DeleteDriverBySSNCommand request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetDriverViewModel>("SSN is required!");

        if (!await _context.Drivers.IsExist(d => d.SSN.Equals(request.SSN)))
            return NotFound<GetDriverViewModel>($"driver with this SSN: {request.SSN} not found");

        await _context.Drivers.ExecuteDeleteAsync(d => d.SSN.Equals(request.SSN));

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