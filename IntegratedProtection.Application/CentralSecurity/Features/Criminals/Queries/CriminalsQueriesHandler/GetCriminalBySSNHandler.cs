using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;

namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueriesHandler;

public sealed class GetCriminalBySSNHandler :
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


