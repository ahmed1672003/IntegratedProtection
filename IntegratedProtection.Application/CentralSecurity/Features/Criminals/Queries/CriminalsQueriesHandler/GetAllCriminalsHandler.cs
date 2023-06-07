using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;

namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueriesHandler;

public sealed class GetAllCriminalsHandler :
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


