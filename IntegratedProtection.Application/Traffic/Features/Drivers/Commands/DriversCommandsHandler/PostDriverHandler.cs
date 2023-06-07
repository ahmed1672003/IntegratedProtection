using IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands.DriversCommandsHandler;
#region Post Driver Handlers
public sealed class PostDriverHandler :
    ResponseHandler,
    IRequestHandler<PostDriverCommand, Response<GetDriverViewModel>>
{
    public PostDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>>
        Handle(PostDriverCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Driver>(request.ViewModel);
        await _context.Drivers.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error");
        }

        var resultModel = await (await _context.Drivers.GetAllAsync())
            .OrderBy(e => e.Id).LastOrDefaultAsync();

        var resultViewModel = _mapper.Map<GetDriverViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion