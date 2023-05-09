namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands;

#region Post Car Handlers
public class PostCarHandler :
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

#region Put Car Handlers
public class PutCarHandler :
    ResponseHandler,
    IRequestHandler<PutCarCommand, Response<GetCarViewModel>>
{
    public PutCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(PutCarCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist(c => c.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCarViewModel>($"car with this id:{request.ViewModel.Id} not found !");

        var model = _mapper.Map<Car>(request.ViewModel);
        var resultModel = await _context.Cars.UpdateAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return BadRequest<GetCarViewModel>("Internal server error ");
        }
        var resultViewModel = _mapper.Map<GetCarViewModel>(resultModel);
        return Accepted(resultViewModel, "Updated car success !");
    }
}

#endregion


#region Delete Car Handlers
public class DeleteCarByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteCarByIdCommand, Response<GetCarViewModel>>
{
    public DeleteCarByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>> Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetCarViewModel>($"id is required !");

        if (!await _context.Cars.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetCarViewModel>($"car with this id:{request.Id} not found !");

        await _context.Cars.ExecuteDeleteAsync(c => c.Id.Equals(request.Id));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return BadRequest<GetCarViewModel>("Internal server error ");
        }

        return Delete<GetCarViewModel>("Deleted car success !");
    }
}

public class DeleteCarByPlateHandler :
    ResponseHandler,
    IRequestHandler<DeleteCarByPlateCommand, Response<GetCarViewModel>>
{
    public DeleteCarByPlateHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>> Handle(DeleteCarByPlateCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist(c => c.Letters.Equals(request.Letters) && c.Number.Equals(request.Number)))
            return NotFound<GetCarViewModel>($"car with this letters:{request.Letters} & numbers:{request.Number} not found !");

        await _context.Cars.ExecuteDeleteAsync(c => c.Letters.Equals(request.Letters) && c.Number.Equals(request.Number));

        return Delete<GetCarViewModel>("car deleted success !");
    }
}

public class DeleteAllCarsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCarsCommand, Response<GetCarViewModel>>
{
    public DeleteAllCarsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>> Handle(DeleteAllCarsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist())
            return NotFound<GetCarViewModel>("no cars founded !");

        await _context.Cars.ExecuteDeleteAsync();

        return Delete<GetCarViewModel>("deleted all cars success !");
    }
}
#endregion

