namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands;
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


#region Delete
public sealed class DeleteCarDriverHandler :
    ResponseHandler,
    IRequestHandler<DeleteCarDriverCommand, Response<GetCarDriverViewModel>>
{
    public DeleteCarDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarDriverViewModel>>
        Handle(DeleteCarDriverCommand request, CancellationToken cancellationToken)
    {
        if (request.CarId.Equals(null) || request.DriverId.Equals(null))
            return BadRequest<GetCarDriverViewModel>($"CarId & DriverId are required !");

        if (!await _context.CarsDrivers.IsExist(
            cd => cd.CarId.Equals(request.CarId) &&
            cd.DriverId.Equals(request.DriverId)))
            return NotFound<GetCarDriverViewModel>
                ($"car driver with carId: {request.CarId} & driverId: {request.DriverId} are not founded !");

        await _context.CarsDrivers.ExecuteDeleteAsync(
            cd => cd.CarId.Equals(request.CarId) &&
            cd.DriverId.Equals(request.DriverId));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCarDriverViewModel>("Internal server error !");
        }

        return Delete<GetCarDriverViewModel>("deleted success !");
    }
}

public sealed class DeleteAllCarsDriversHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCarsDriversCommand, Response<GetCarDriverViewModel>>
{
    public DeleteAllCarsDriversHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarDriverViewModel>>
        Handle(DeleteAllCarsDriversCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.CarsDrivers.IsExist())
            return NotFound<GetCarDriverViewModel>("no cars drivers founded !");

        await _context.CarsDrivers.ExecuteDeleteAsync();

        return Delete<GetCarDriverViewModel>("deleted all cars drivers success !");
    }
}
#endregion

