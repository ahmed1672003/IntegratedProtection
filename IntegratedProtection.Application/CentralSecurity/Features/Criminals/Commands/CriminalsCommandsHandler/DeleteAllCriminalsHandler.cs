
namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommandsHandler;


public sealed class DeleteAllCriminalsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCriminalsCommand, Response<GetCriminalViewModel>>
{
    public DeleteAllCriminalsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(DeleteAllCriminalsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Criminals.IsExist())
            return NotFound<GetCriminalViewModel>("criminals not founded !");

        await _context.Criminals.ExecuteDeleteAsync();

        return Delete<GetCriminalViewModel>("deleted success !");
    }
}
