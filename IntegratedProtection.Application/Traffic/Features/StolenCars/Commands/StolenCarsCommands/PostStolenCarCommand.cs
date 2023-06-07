namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;

public record PostStolenCarCommand(PostStolenCarViewModel ViewModel) : IRequest<Response<GetStolenCarViewModel>>;


