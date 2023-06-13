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

public sealed class GetStolenCarWithTrafficOfficerHandler :
    ResponseHandler,
    IRequestHandler<GetStolenCarWithTrafficOfficerQuery, Response<GetStolenCarWithTrafficOfficerViewModel>>
{
    public GetStolenCarWithTrafficOfficerHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetStolenCarWithTrafficOfficerViewModel>>
        Handle(GetStolenCarWithTrafficOfficerQuery request, CancellationToken cancellationToken)
    {
        if (request.Number.Equals(null) && request.Letters.Equals(null))
            return BadRequest<GetStolenCarWithTrafficOfficerViewModel>(message: "Number & Letters are required !");

        if (!await _context.Cars.IsExist(c => c.Letters.Equals(request.Letters) && c.Number.Equals(request.Number)))
            return NotFound<GetStolenCarWithTrafficOfficerViewModel>(message: "car not found !");
        var model = await _context.StolenCars.GetStolenCarWithTrafficOfficerAsync(request.Number, request.Letters);

        if (model.Equals(null))
            return NotFound<GetStolenCarWithTrafficOfficerViewModel>(message: "car is not stolen !");

        return Success(new GetStolenCarWithTrafficOfficerViewModel()
        {
            GetStolenCarViewModel = _mapper.Map<GetStolenCarViewModel>(model),
            GetTrafficOfficerViewModel = _mapper.Map<GetTrafficOfficerViewModel>(model.TrafficOfficer)
        });
    }
}


