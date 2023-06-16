using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommandsHandlers;

public class DeleteFileByIdCommandHandler :
    ResponseHandler,
    IRequestHandler<DeleteFileByIdCommand, Response<GetFileViewModel>>
{
    private readonly IFileHelper _fileHelper;

    public DeleteFileByIdCommandHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<GetFileViewModel>>
        Handle(DeleteFileByIdCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id) || string.IsNullOrWhiteSpace(request.Id))
            return BadRequest<GetFileViewModel>("id is required !");

        if (!await _context.UploadedFiles.IsExist(f => f.Id.Equals(request.Id)))
            return NotFound<GetFileViewModel>("not found !");
        try
        {
            await _context.UploadedFiles.ExecuteDeleteAsync(f => f.Id.Equals(request.Id));
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetFileViewModel>("internal server error !");
        }

        return Delete<GetFileViewModel>();
    }
}
