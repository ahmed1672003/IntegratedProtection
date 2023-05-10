namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries;

public class GetCriminalByIdHandler :
    ResponseHandler,
    IRequestHandler<GetCriminalByIdQuery, Response<GetCriminalViewModel>>
{
    public GetCriminalByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(GetCriminalByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetCriminalViewModel>("Id is required !");

        if (!await _context.Criminals.IsExist(e => e.Id.Equals(request.Id)))
            return NotFound<GetCriminalViewModel>($"criminal with this Id: {request.Id} not found !");

        var model = await _context.Criminals.GetAsync(e => e.Id.Equals(request.Id));
        var viewModel = _mapper.Map<GetCriminalViewModel>(model);
        return Success(viewModel);
    }
}

public class GetCriminalBySSNHandler :
    ResponseHandler,
    IRequestHandler<GetCriminalBySSNQuery, Response<GetCriminalViewModel>>
{
    public GetCriminalBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(GetCriminalBySSNQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetCriminalViewModel>("Id is required !");

        if (!await _context.Criminals.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetCriminalViewModel>($"criminal with this Id: {request.SSN} not found !");

        var model = await _context.Criminals.GetAsync(e => e.SSN.Equals(request.SSN));
        var viewModel = _mapper.Map<GetCriminalViewModel>(model);
        return Success(viewModel);
    }
}

public class GetAllCriminalsHandler :
    ResponseHandler,
    IRequestHandler<GetAllCriminalsQuery, Response<IEnumerable<GetCriminalViewModel>>>
{
    public GetAllCriminalsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetCriminalViewModel>>>
        Handle(GetAllCriminalsQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Criminals.IsExist())
            return NotFound<IEnumerable<GetCriminalViewModel>>("no criminals founded !");

        var models = await _context.Criminals.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetCriminalViewModel>>(models);

        return Success(viewModels);
    }
}


