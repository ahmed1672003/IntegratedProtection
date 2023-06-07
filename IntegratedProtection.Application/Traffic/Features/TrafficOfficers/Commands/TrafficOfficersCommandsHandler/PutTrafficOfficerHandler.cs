using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommandsHandler;
#region Post TrafficOfficer Handler
#endregion

#region Put TrafficOfficer Handler
public sealed class PutTrafficOfficerHandler :
    ResponseHandler,
    IRequestHandler<PutTrafficOfficerCommand, Response<GetTrafficOfficerViewModel>>
{
    public PutTrafficOfficerHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(PutTrafficOfficerCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.Id.Equals(null))
            return BadRequest<GetTrafficOfficerViewModel>("id is required !");

        if (!await _context.TrafficOfficers.IsExist(t => t.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetTrafficOfficerViewModel>($"Traffic officer with this id: {request.ViewModel.Id} not found !");

        var model = _mapper.Map<TrafficOfficer>(request.ViewModel);

        await _context.TrafficOfficers.UpdateAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetTrafficOfficerViewModel>("Internal server error !");
        }
        var resultModel =
            await _context.TrafficOfficers.GetAsync(t => t.Id.Equals(request.ViewModel.Id));

        var resultViewModel = _mapper.Map<GetTrafficOfficerViewModel>(resultModel);

        return Success(resultViewModel, message: "update traffic officer success !");
    }
}
#endregion

