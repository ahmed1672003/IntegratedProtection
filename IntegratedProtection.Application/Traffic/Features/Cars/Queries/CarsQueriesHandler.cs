namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries;

public class GetCarByIdHandler :
    ResponseHandler,
    IRequestHandler<GetCarByIdQuery, Response<GetCarViewModel>>
{
    public GetCarByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetCarViewModel>("id is required !");

        if (!await _context.Cars.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetCarViewModel>($"car with this id:{request.Id} not found !");

        var model = await _context.Cars.GetAsync(c => c.Id.Equals(request.Id));

        var viewModel = _mapper.Map<GetCarViewModel>(model);

        return Success(viewModel, message: $"retrieve car with this id: {request.Id} success !");
    }
}

public class GetCarByPlateHandler :
    ResponseHandler,
    IRequestHandler<GetCarByPlateQuery, Response<GetCarViewModel>>
{
    public GetCarByPlateHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(GetCarByPlateQuery request, CancellationToken cancellationToken)
    {
        if (request.Letters.Equals(null) || request.Number.Equals(null))
            return BadRequest<GetCarViewModel>("letters & number required !");

        if (!await _context.Cars.IsExist(
            c => c.Number.Equals(request.Number) && c.Letters.Equals(request.Letters)))
            return NotFound<GetCarViewModel>($"no car with this number:{request.Number} & letters: {request.Letters} founded !");

        var model = await _context.Cars.GetAsync(c => c.Number.Equals(request.Number) && c.Letters.Equals(request.Letters));

        var viewModel = _mapper.Map<GetCarViewModel>(model);

        return Success(viewModel, message: "car retrieved success !");
    }
}

public class GetAllCarsHandler :
    ResponseHandler,
    IRequestHandler<GetAllCarsQuery, Response<IEnumerable<GetCarViewModel>>>
{
    public GetAllCarsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetCarViewModel>>>
        Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist())
            return NotFound<IEnumerable<GetCarViewModel>>("no cars founded !");

        var models = await _context.Cars.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetCarViewModel>>(models);

        return Success(viewModels, message: "retrieve all cars success !");
    }
}
