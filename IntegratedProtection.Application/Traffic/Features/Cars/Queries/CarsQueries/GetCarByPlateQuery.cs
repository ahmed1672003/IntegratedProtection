namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

public record GetCarByPlateQuery(string Plate) : IRequest<Response<GetCarViewModel>>;

