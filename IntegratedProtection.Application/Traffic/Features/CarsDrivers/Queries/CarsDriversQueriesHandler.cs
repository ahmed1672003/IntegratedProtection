namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Queries;

public class GetAllCarsDriversHandler :
    ResponseHandler,
    IRequestHandler<GetAllCarsDriversQuery, Response<IEnumerable<GetCarDriverViewModel>>>
{
    public GetAllCarsDriversHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetCarDriverViewModel>>>
        Handle(GetAllCarsDriversQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.CarsDrivers.IsExist())
            return NotFound<IEnumerable<GetCarDriverViewModel>>("no cars drivers founded !");

        var models = await _context.CarsDrivers.GetAllAsync();
        var viewModels = _mapper.Map<IEnumerable<GetCarDriverViewModel>>(models);

        return Success(viewModels, message: "all cars drivers retrieved successfully !");
    }
}


