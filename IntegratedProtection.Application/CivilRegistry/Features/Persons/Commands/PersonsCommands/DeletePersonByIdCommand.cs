namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

public record DeletePersonByIdCommand(int Id) : IRequest<Response<GetPersonViewModel>>;

