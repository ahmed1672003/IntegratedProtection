using IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommandsHandler;
#region Persons Handler
#region => Put Person Handler

#endregion

#region => Delete Person Handler
public sealed class DeletePersonByIdHandler :
    ResponseHandler,
    IRequestHandler<DeletePersonByIdCommand, Response<GetPersonViewModel>>
{
    public DeletePersonByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Persons.IsExist(e => e.Id == request.Id))
            return NotFound<GetPersonViewModel>("person not found !");

        await _context.Persons.ExecuteDeleteAsync(e => e.Id == request.Id);

        return Delete<GetPersonViewModel>("person deleted success !");
    }
}

#endregion
#endregion
