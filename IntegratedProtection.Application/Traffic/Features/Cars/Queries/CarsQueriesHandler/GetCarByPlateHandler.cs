using IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueriesHandler;

public sealed class GetCarByPlateHandler :
    ResponseHandler,
    IRequestHandler<GetCarByPlateQuery, Response<GetCarViewModel>>
{
    public GetCarByPlateHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetCarViewModel>>
        Handle(GetCarByPlateQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Plate) || string.IsNullOrWhiteSpace(request.Plate))
            return BadRequest<GetCarViewModel>("letters & number required !");

        var number = new String(request.Plate.Where(Char.IsDigit).ToArray()).ToLower();
        var letters = new String(request.Plate.Where(Char.IsLetter).ToArray()).ToLower();

        if (!await _context.Cars.IsExist(
            c => c.Number.ToLower().Equals(number) && c.Letters.ToLower().Equals(letters)))
            return NotFound<GetCarViewModel>($"no car with this number:{number} & letters: {letters} founded !");

        var model = await _context.Cars.GetAsync(
            c => c.Number.ToLower().Equals(number) && c.Letters.ToLower().Equals(letters));

        var viewModel = _mapper.Map<GetCarViewModel>(model);

        return Success(viewModel, message: "car retrieved success !");
    }
}
