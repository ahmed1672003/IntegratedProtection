using IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueriesHandler;

public sealed class GetCarByIdHandler :
    ResponseHandler,
    IRequestHandler<GetCarByIdQuery, Response<GetCarViewModel>>
{
    public GetCarByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetCarViewModel>("id is required !");

        if (!await _context.Cars.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetCarViewModel>($"car with this id:{request.Id} not found !");

        var model = await _context.Cars.GetAsync(c => c.Id.Equals(request.Id));

        var viewModel = _mapper.Map<GetCarViewModel>(model);

        return Success(viewModel, message: $"retrieve car with this id: {request.Id} success !");
    }
}
