using IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueriesHandler;

public sealed class GetAllCarsHandler :
    ResponseHandler,
    IRequestHandler<GetAllCarsQuery, Response<IEnumerable<GetCarViewModel>>>
{


    public GetAllCarsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetCarViewModel>>>
        Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist())
            return NotFound<IEnumerable<GetCarViewModel>>("no cars founded !");

        var models = await _context.Cars.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetCarViewModel>>(models);

        return Success(viewModels, message: "retrieve all cars success !");
    }
}
