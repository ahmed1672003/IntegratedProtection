using IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommandsHandler;
#region POST
public sealed class PostCarDriverHandler :
    ResponseHandler,
    IRequestHandler<PostCarDriverCommand, Response<GetCarDriverViewModel>>
{
    public PostCarDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarDriverViewModel>>
        Handle(PostCarDriverCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<CarDriver>(request.ViewModel);

        var resultModel = await _context.CarsDrivers.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return BadRequest<GetCarDriverViewModel>("Internal server error");
        }

        var resultViewModel = _mapper.Map<GetCarDriverViewModel>(resultModel);
        return Created(resultViewModel);
    }

}
#endregion

