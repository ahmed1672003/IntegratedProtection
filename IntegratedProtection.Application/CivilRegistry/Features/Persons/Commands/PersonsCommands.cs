namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;

public record PostPersonCommand(PostPersonViewModel ViewModel) : IRequest<Response<GetPersonViewModel>>;
public record PutPersonCommand(PutPersonViewModel ViewModel) : IRequest<Response<GetPersonViewModel>>;





