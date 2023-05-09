namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands;

public record PostStolenCarCommand(PostStolenCarViewModel ViewModel) : IRequest<Response<GetStolenCarViewModel>>;
