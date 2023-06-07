namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

public record PutPersonCommand(PutPersonViewModel ViewModel) : IRequest<Response<GetPersonViewModel>>;

