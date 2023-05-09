namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands;

public record PostDriverCommand(PostDriverViewModel ViewModel) : IRequest<Response<GetDriverViewModel>>;

public record PutDriverCommand(PutDriverViewModel ViewModel) : IRequest<Response<GetDriverViewModel>>;

public record DeleteDriverByIdCommand(int? Id) : IRequest<Response<GetDriverViewModel>>;

public record DeleteDriverBySSNCommand(string SSN) : IRequest<Response<GetDriverViewModel>>;

public record DeleteAllDriversCommand() : IRequest<Response<GetDriverViewModel>>;






