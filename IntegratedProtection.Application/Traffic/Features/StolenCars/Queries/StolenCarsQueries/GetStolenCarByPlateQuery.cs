namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;

public record GetStolenCarByPlateQuery(string Plate) :
IRequest<Response<GetStolenCarWithTrafficOfficerViewModel>>;
