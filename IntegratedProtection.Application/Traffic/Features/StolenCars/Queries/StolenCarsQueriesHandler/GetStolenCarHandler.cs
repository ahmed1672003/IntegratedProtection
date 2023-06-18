using IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;
namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueriesHandler;

public sealed class GetStolenCarByPlateHandler :
    ResponseHandler,
    IRequestHandler<GetStolenCarByPlateQuery, Response<GetStolenCarWithTrafficOfficerViewModel>>
{
    public GetStolenCarByPlateHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetStolenCarWithTrafficOfficerViewModel>>
        Handle(GetStolenCarByPlateQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Letters) || string.IsNullOrWhiteSpace(request.Letters)
            || string.IsNullOrEmpty(request.Number) || string.IsNullOrWhiteSpace(request.Number))
            return BadRequest<GetStolenCarWithTrafficOfficerViewModel>("letters & number field are required !");

        if (!await _context.Cars.IsExist(c => c.Letters.Equals(request.Letters) && c.Number.Equals(request.Number)))
            return NotFound<GetStolenCarWithTrafficOfficerViewModel>("car not founded !");

        var modelState =
            await _context.Cars.
            GetStolenCarStateAsync(c => c.Number.Equals(request.Number) && c.Letters.Equals(request.Letters));

        if (modelState.state)
        {
            return Success(new GetStolenCarWithTrafficOfficerViewModel()
            {
                GetTrafficOfficerViewModel = _mapper.Map<GetTrafficOfficerViewModel>(modelState.car.StolenCars.FirstOrDefault().TrafficOfficer),
                GetStolenCarViewModel = _mapper.Map<GetStolenCarViewModel>(modelState.car.StolenCars.FirstOrDefault())
            });
        }
        else
        {
            return NotFound<GetStolenCarWithTrafficOfficerViewModel>("car is not stolen ");
        }
    }
}
