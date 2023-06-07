namespace IntegratedProtection.Application.Traffic.Features.Cars.Queries.CarsQueries;

public record GetCarByIdQuery(int? Id) : IRequest<Response<GetCarViewModel>>;

