using IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;

namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueriesHandler;


public sealed class GetStolenCarHandler :
    ResponseHandler,
    IRequestHandler<GetAllStolenCarsQuery, Response<IEnumerable<GetStolenCarViewModel>>>
{
    public GetStolenCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetStolenCarViewModel>>>
        Handle(GetAllStolenCarsQuery request, CancellationToken cancellationToken)
    {

        if (!await _context.StolenCars.IsExist())
            return NotFound<IEnumerable<GetStolenCarViewModel>>("no stolen cars founded !");

        var models = await _context.StolenCars.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetStolenCarViewModel>>(models);

        return Success(viewModels, message: "all stolen cars retrieved successfully !");
    }
}


