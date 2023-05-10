namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands;

public record PostCriminalCommand(PostCriminalViewModel ViewModel) : IRequest<Response<GetCriminalViewModel>>;

public record PutCriminalCommand(PutCriminalViewModel ViewModel) : IRequest<Response<GetCriminalViewModel>>;

public record DeleteCriminalByIdCommand(int? Id) : IRequest<Response<GetCriminalViewModel>>;

public record DeleteCriminalBySSNCommand(string SSN) : IRequest<Response<GetCriminalViewModel>>;

public record DeleteAllCriminalsCommand() : IRequest<Response<GetCriminalViewModel>>;


