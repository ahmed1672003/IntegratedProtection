namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

public record GetCarByPlateQuery(string Letters, string Number) : IRequest<Response<GetCarViewModel>>;

