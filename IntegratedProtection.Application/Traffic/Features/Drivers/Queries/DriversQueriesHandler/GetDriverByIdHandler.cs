using IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueriesHandler;

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
