namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;

public record PostPersonCommand(PostPersonViewModel ViewModel) : IRequest<Response<GetPersonViewModel>>;
public record PutPersonCommand(PutPersonViewModel ViewModel) : IRequest<Response<GetPersonViewModel>>;
public record DeletePersonByIdCommand(int Id) : IRequest<Response<GetPersonViewModel>>;
public record DeletePersonBySSNCommand(string SSN) : IRequest<Response<GetPersonViewModel>>;





