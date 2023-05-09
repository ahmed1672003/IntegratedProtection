namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries;

public class GetAllTrafficOfficersHandler :
    ResponseHandler,
    IRequestHandler<GetAllTrafficOfficersQuery, Response<IEnumerable<GetTrafficOfficerViewModel>>>
{
    public GetAllTrafficOfficersHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }
    public async Task<Response<IEnumerable<GetTrafficOfficerViewModel>>> Handle(GetAllTrafficOfficersQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.TrafficOfficers.IsExist())
            return NoContent<IEnumerable<GetTrafficOfficerViewModel>>("no traffic officers founded !");

        var models = await _context.TrafficOfficers.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetTrafficOfficerViewModel>>(models);

        return Success(viewModels, message: "TrafficOfficers retrieved successfully !");
    }
}

public class GetTrafficOfficerByIdHandler :
    ResponseHandler,
    IRequestHandler<GetTrafficOfficerByIdQuery, Response<GetTrafficOfficerViewModel>>
{
    public GetTrafficOfficerByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(GetTrafficOfficerByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetTrafficOfficerViewModel>("id is required !");

        if (!await _context.TrafficOfficers.IsExist(t => t.Id.Equals(request.Id)))
            return NotFound<GetTrafficOfficerViewModel>($"traffic officer with this id: {request.Id} not found !");

        var model = await _context.TrafficOfficers.GetAsync(t => t.Id.Equals(request.Id));
        var viewModel = _mapper.Map<GetTrafficOfficerViewModel>(model);
        return Success(viewModel, message: $"traffic officer with this id: {request.Id} retrieved successfully !");
    }
}


