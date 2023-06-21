using IntegratedProtection.Application.Folders.CarFiles.Commands.FilesCommands;

namespace IntegratedProtection.Application.Folders.CarFiles.Commands.FilesCommandsHandlers;
public class DeleteAllCarFilesCommandHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCarFilesCommand, Response<string>>
{
    public DeleteAllCarFilesCommandHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<string>>
        Handle(DeleteAllCarFilesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _context.CarFiles.ExecuteDeleteAsync();
            return Delete<string>();
        }
        catch (Exception)
        {
            return BadRequest<string>("internal server error");
        }
    }
}
