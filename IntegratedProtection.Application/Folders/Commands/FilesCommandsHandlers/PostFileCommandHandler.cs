using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.ViewModels;
using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommandsHandlers;
public class PostFileCommandHandler :
    ResponseHandler,
    IRequestHandler<PostFileCommand, Response<PostFileViewModel>>
{
    public PostFileCommandHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<PostFileViewModel>>
        Handle(PostFileCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.FileViewModel.FileFullPath) || string.IsNullOrWhiteSpace(request.FileViewModel.FileFullPath))
            return BadRequest<PostFileViewModel>(message: "File field is required !");

        var uploadedFile = _mapper.Map<UploadedFile>(request.FileViewModel);
        await _context.UploadedFiles.AddAsync(uploadedFile);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<PostFileViewModel>("Internal server error !");
        }

        var result = _mapper.Map<PostFileViewModel>(
            await _context.UploadedFiles.GetAsync(u => u.FileFullPath.Equals(request.FileViewModel.FileFullPath)));
        return Success(result);
    }
}
