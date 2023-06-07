namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

public record PostPersonCommand(PostPersonViewModel ViewModel) : IRequest<Response<GetPersonViewModel>>;

