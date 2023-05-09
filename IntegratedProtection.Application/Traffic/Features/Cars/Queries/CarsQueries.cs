namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries;

public record GetCarByIdQuery(int? Id) : IRequest<Response<GetCarViewModel>>;

public record GetCarByPlateQuery(string Letters, string Number) : IRequest<Response<GetCarViewModel>>;

public record GetAllCarsQuery() : IRequest<Response<IEnumerable<GetCarViewModel>>>;

