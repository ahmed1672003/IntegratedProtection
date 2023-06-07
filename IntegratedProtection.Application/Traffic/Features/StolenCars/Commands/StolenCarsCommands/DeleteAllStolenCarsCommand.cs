namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;

public record DeleteAllStolenCarsCommand() : IRequest<Response<GetStolenCarViewModel>>;


