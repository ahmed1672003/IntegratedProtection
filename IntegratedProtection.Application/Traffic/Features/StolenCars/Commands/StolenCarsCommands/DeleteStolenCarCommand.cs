namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;

public record DeleteStolenCarCommand(int? CarId, int? TrafficOfficerId) : IRequest<Response<GetStolenCarViewModel>>;


