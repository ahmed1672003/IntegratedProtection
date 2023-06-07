namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

public record PostTrafficOfficerCommand(PostTrafficOfficerViewModel ViewModel) : IRequest<Response<GetTrafficOfficerViewModel>>;

