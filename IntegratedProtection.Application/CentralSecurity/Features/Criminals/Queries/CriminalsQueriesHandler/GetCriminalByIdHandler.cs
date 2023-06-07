using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueries;

namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueriesHandler;

public sealed class GetCriminalByIdHandler :
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


