namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries;

public sealed class GetDriverByIdHandler :
    ResponseHandler,
    IRequestHandler<GetDriverByIdQuery, Response<GetDriverViewModel>>
{
    public GetDriverByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetDriverViewModel>("id is required !");

        if (!await _context.Drivers.IsExist(d => d.Id.Equals(request.Id)))
            return NotFound<GetDriverViewModel>($"driver with this id: {request.Id} not found !");
        var model = await _context.Drivers.GetAsync(d => d.Id.Equals(request.Id));

        var viewModel = _mapper.Map<GetDriverViewModel>(model);

        return Success(viewModel, "retrieve driver success !");
    }
}

public sealed class GetDriverBySSNHandler :
    ResponseHandler,
    IRequestHandler<GetDriverBySSNQuery, Response<GetDriverViewModel>>
{
    public GetDriverBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(GetDriverBySSNQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetDriverViewModel>("SSN is required !");

        if (!await _context.Drivers.IsExist(d => d.SSN.Equals(request.SSN)))
            return NotFound<GetDriverViewModel>($"driver with this SSN: {request.SSN} not found !");

        var model = await _context.Drivers.GetAsync(d => d.SSN.Equals(request.SSN));

        var viewModel = _mapper.Map<GetDriverViewModel>(model);

        return Success(viewModel, "retrieve driver success !");
    }
}

public sealed class GetAllDriversHandler :
    ResponseHandler,
    IRequestHandler<GetAllDriversQuery, Response<IEnumerable<GetDriverViewModel>>>
{
    public GetAllDriversHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetDriverViewModel>>>
        Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Drivers.IsExist())
            return NoContent<IEnumerable<GetDriverViewModel>>("no drivers founded !");

        var models = await _context.Drivers.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetDriverViewModel>>(models);

        return Success(viewModels, message: "retrieve drivers success !");
    }
}
