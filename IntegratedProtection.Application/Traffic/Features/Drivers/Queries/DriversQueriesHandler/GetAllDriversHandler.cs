using IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueries;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Queries.DriversQueriesHandler;

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
