namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands;

public record PostStolenCarCommand(PostStolenCarViewModel ViewModel) : IRequest<Response<GetStolenCarViewModel>>;
public record DeleteStolenCarCommand(int? CarId , int? TrafficOfficerId): IRequest<Response<GetStolenCarViewModel>>;

public record DeleteAllStolenCarsCommand() : IRequest<Response<GetStolenCarViewModel>>;


