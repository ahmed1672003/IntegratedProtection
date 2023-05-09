namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries;

public record GetStolenCarWithTrafficOfficerAndCar(int? TrafficOfficerId, int? CarId) : IRequest<Response<GetStolenCarViewModel>>;


