namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands;

public record PostTrafficOfficerCommand(PostTrafficOfficerViewModel ViewModel) : IRequest<Response<GetTrafficOfficerViewModel>>;
public record PutTrafficOfficerCommand(PutTrafficOfficerViewModel ViewModel) : IRequest<Response<GetTrafficOfficerViewModel>>;
public record DeleteTrafficOfficerByIdCommand(int? Id) : IRequest<Response<GetTrafficOfficerViewModel>>;
public record DeleteAllTrafficOfficersCommand() : IRequest<Response<GetTrafficOfficerViewModel>>;

