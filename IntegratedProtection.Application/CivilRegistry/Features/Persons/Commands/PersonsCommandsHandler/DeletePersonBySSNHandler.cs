using IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommandsHandler;
#region Persons Handler
#region => Delete Person Handler

public sealed class DeletePersonBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeletePersonBySSNCommand, Response<GetPersonViewModel>>
{
    public DeletePersonBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(DeletePersonBySSNCommand request, CancellationToken cancellationToken)
    {

        if (!await _context.Persons.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetPersonViewModel>("person not found !");

        await _context.Persons.ExecuteDeleteAsync(e => e.SSN.Equals(request.SSN));

        return Delete<GetPersonViewModel>("person deleted success !");
    }
}

#endregion
#endregion
