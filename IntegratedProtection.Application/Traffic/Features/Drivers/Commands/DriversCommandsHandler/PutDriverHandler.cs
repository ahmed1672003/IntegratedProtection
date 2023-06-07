using IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommandsHandler;
#region Post Driver Handlers
#endregion

#region Put Driver Handlers
public sealed class PutDriverHandler :
    ResponseHandler,
    IRequestHandler<PutDriverCommand, Response<GetDriverViewModel>>
{
    public PutDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(PutDriverCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.Id.Equals(null))
            return BadRequest<GetDriverViewModel>("id is required !");

        if (!await _context.Drivers.IsExist(d => d.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetDriverViewModel>($"driver with this id: {request.ViewModel.Id} not found");

        var model = _mapper.Map<Driver>(request.ViewModel);
        await _context.Drivers.UpdateAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }

        var resultViewModel = _mapper.Map<GetDriverViewModel>(model);
        return Accepted(resultViewModel, "update driver success !");
    }
}
#endregion