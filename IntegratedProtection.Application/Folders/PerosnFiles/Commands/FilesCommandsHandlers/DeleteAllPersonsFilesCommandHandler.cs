using IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommandsHandlers;

public class DeleteAllPersonsFilesCommandHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllPersonsFilesCommand, Response<GetFileViewModel>>
{
    public DeleteAllPersonsFilesCommandHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetFileViewModel>>
        Handle(DeleteAllPersonsFilesCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.PersonFiles.IsExist())
            return NotFound<GetFileViewModel>("no files founded !");
        try
        {
            await _context.PersonFiles.ExecuteDeleteAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetFileViewModel>();
        }
        return Delete<GetFileViewModel>();
    }
}
