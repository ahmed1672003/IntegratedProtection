namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;

public record GetStolenCarByPlateQuery(string Number, string Letters) : 
IRequest<Response<GetStolenCarWithTrafficOfficerViewModel>>;
