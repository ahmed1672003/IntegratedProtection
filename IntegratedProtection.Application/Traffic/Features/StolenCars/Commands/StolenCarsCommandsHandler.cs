namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands;

#region Post
public class PostStolenCarHandler :
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


#region Delete


public class DeleteStolenCarHandler :
    ResponseHandler,
    IRequestHandler<DeleteStolenCarCommand, Response<GetStolenCarViewModel>>
{
    public DeleteStolenCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetStolenCarViewModel>>
        Handle(DeleteStolenCarCommand request, CancellationToken cancellationToken)
    {
        if (request.CarId.Equals(null) || request.TrafficOfficerId.Equals(null))
            return BadRequest<GetStolenCarViewModel>("CarId & TrafficOfficerId are required !");

        if (!
            await _context.StolenCars.IsExist(s => s.CarId.Equals(request.CarId) &&
            s.TrafficOfficerId.Equals(request.TrafficOfficerId)))
            return NotFound<GetStolenCarViewModel>
                ($"stolen car with this carId:{request.CarId} & trafficOfficerId:{request.TrafficOfficerId}");

        await _context.StolenCars.ExecuteDeleteAsync(s =>
        s.CarId.Equals(request.CarId) &&
        s.TrafficOfficerId.Equals(request.TrafficOfficerId));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetStolenCarViewModel>("Internal server error !");
        }

        return Delete<GetStolenCarViewModel>("deleted successfully! ");
    }
}

public class DeleteAllStolenCarsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllStolenCarsCommand, Response<GetStolenCarViewModel>>
{
    public DeleteAllStolenCarsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetStolenCarViewModel>>
        Handle(DeleteAllStolenCarsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.StolenCars.IsExist())
            return NotFound<GetStolenCarViewModel>("mo stolen cars founded !");
        await _context.StolenCars.ExecuteDeleteAsync();

        return Delete<GetStolenCarViewModel>("deleted all stolen cars success !");
    }
}
#endregion
