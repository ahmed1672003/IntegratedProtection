using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueries;

namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Queries.TrafficOfficersQueriesHandler;

public sealed class GetTrafficOfficerByIdHandler :
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


