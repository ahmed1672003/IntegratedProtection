namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Queries.StolenCarsQueries;

public record GetStolenCarWithTrafficOfficerQuery(string Number, string Letters) : IRequest<Response<GetStolenCarWithTrafficOfficerViewModel>>;


