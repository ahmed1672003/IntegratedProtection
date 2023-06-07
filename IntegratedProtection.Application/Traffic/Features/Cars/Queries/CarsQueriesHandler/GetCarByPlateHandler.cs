using IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueriesHandler;

public sealed class GetCarByPlateHandler :
    ResponseHandler,
    IRequestHandler<GetCarByPlateQuery, Response<GetCarViewModel>>
{
    public GetCarByPlateHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(GetCarByPlateQuery request, CancellationToken cancellationToken)
    {
        if (request.Letters.Equals(null) || request.Number.Equals(null))
            return BadRequest<GetCarViewModel>("letters & number required !");

        if (!await _context.Cars.IsExist(
            c => c.Number.Equals(request.Number) && c.Letters.Equals(request.Letters)))
            return NotFound<GetCarViewModel>($"no car with this number:{request.Number} & letters: {request.Letters} founded !");

        var model = await _context.Cars.GetAsync(c => c.Number.Equals(request.Number) && c.Letters.Equals(request.Letters));

        var viewModel = _mapper.Map<GetCarViewModel>(model);

        return Success(viewModel, message: "car retrieved success !");
    }
}
