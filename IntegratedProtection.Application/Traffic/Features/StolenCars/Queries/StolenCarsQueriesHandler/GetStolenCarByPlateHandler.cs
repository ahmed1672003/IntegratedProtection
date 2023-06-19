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
        if (string.IsNullOrEmpty(request.Plate) || string.IsNullOrWhiteSpace(request.Plate))
            return BadRequest<GetStolenCarWithTrafficOfficerViewModel>("letters & number field are required !");

        var number = new String(request.Plate.Where(Char.IsDigit).ToArray()).ToLower();

        var letters = new String(request.Plate.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)).ToArray()).Trim().ToLower();

        if (!await _context.Cars.IsExist(c => c.Letters.ToLower().Equals(letters) && c.Number.ToLower().Equals(number)))
            return NotFound<GetStolenCarWithTrafficOfficerViewModel>("car not founded !");

        var modelState =
            await _context.Cars.
            GetStolenCarStateAsync(c => c.Number.ToLower().Equals(number) && c.Letters.ToLower().Equals(letters));

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
            return Success<GetStolenCarWithTrafficOfficerViewModel>(null, "car is not stolen ");
        }
    }
}
