namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

public record DeleteTrafficOfficerByIdCommand(int? Id) : IRequest<Response<GetTrafficOfficerViewModel>>;

