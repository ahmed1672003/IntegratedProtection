using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueries;

namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueriesHandler;

public sealed class GetAllTrafficOfficersHandler :
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


