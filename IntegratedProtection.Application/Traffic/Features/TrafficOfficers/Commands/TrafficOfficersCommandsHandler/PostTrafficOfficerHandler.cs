using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommandsHandler;
#region Post TrafficOfficer Handler
public sealed class PostTrafficOfficerHandler :
    ResponseHandler,
    IRequestHandler<PostTrafficOfficerCommand, Response<GetTrafficOfficerViewModel>>
{
    public PostTrafficOfficerHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(PostTrafficOfficerCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TrafficOfficer>(request.ViewModel);
        await _context.TrafficOfficers.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetTrafficOfficerViewModel>("Internal server error !");
        }

        var resultModel =
            await (await _context.TrafficOfficers.GetAllAsync()).OrderBy(e => e.Id)
            .LastOrDefaultAsync();

        var resultViewModel = _mapper.Map<GetTrafficOfficerViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion

