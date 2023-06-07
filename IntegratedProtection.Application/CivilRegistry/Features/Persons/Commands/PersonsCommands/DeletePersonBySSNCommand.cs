namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

public record DeletePersonBySSNCommand(string SSN) : IRequest<Response<GetPersonViewModel>>;

