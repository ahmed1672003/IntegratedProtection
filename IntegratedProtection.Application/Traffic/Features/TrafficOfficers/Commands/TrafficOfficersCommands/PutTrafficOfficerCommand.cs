namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

public record PutTrafficOfficerCommand(PutTrafficOfficerViewModel ViewModel) : IRequest<Response<GetTrafficOfficerViewModel>>;

