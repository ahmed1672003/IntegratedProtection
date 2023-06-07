using IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommandsHandler;

#region Persons Handler
#region => Delete Person Handler

public sealed class DeleteAllPersonsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllPersonsCommand, Response<GetPersonViewModel>>
{
    public DeleteAllPersonsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(DeleteAllPersonsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Persons.IsExist())
            return NotFound<GetPersonViewModel>("no persons founded !");

        await _context.Persons.ExecuteDeleteAsync();

        return Delete<GetPersonViewModel>("Deleted all persons success !");
    }
}

#endregion
#endregion
