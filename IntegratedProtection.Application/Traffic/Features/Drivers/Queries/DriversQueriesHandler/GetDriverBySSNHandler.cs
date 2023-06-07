using IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueriesHandler;

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
