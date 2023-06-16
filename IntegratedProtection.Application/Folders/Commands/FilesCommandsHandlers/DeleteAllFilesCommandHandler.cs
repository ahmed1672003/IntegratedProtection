using IntegratedProtection.Application.Constants;
using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommandsHandlers;

public class DeleteAllFilesCommandHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllFilesCommand, Response<GetFileViewModel>>
{
    private readonly IFileHelper _fileHelper;
    public DeleteAllFilesCommandHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<GetFileViewModel>>
        Handle(DeleteAllFilesCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.UploadedFiles.IsExist())
            return NotFound<GetFileViewModel>("no files founded !");

        var files = await _context.UploadedFiles.GetAllAsync();

        try
        {
            foreach (var file in files)
            {
                await _fileHelper.DeleteFile(Path.Combine(request.WebRootPath, Stocks.Videos, file.StorageFileName!));
            }

            await _context.UploadedFiles.ExecuteDeleteAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetFileViewModel>();
        }

        return Delete<GetFileViewModel>();
    }
}
