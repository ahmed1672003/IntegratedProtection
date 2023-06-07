using IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommandsHandler;
#region Post
public sealed class PostStolenCarHandler :
    ResponseHandler,
    IRequestHandler<PostStolenCarCommand, Response<GetStolenCarViewModel>>
{
    public PostStolenCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetStolenCarViewModel>>
        Handle(PostStolenCarCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.CarId.Equals(null) || request.ViewModel.TrafficOfficerId.Equals(null))
            return BadRequest<GetStolenCarViewModel>("carId & trafficOfficerId are required !");

        var model = _mapper.Map<StolenCar>(request.ViewModel);

        var resultModel = await _context.StolenCars.AddAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetStolenCarViewModel>("Internal server error !");
        }

        var resultViewModel = _mapper.Map<GetStolenCarViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion
