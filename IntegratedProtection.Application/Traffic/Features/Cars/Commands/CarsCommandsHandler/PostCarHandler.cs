using IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommandsHandler;
#region Post Car Handlers
public sealed class PostCarHandler :
    ResponseHandler,
    IRequestHandler<PostCarCommand, Response<GetCarViewModel>>
{
    public PostCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(PostCarCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Car>(request.ViewModel);
        await _context.Cars.AddAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCarViewModel>("Internal server error ");
        }
        var resultModel = await _context.Cars.GetAsync(
            c => c.Letters.Equals(request.ViewModel.Letters) && c.Number.Equals(request.ViewModel.Number));

        var resultViewModel = _mapper.Map<GetCarViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion

