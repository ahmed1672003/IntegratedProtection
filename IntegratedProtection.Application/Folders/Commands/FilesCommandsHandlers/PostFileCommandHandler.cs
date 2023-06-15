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
        if (request.FileViewModel.FileName is null)
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
            await _context.UploadedFiles.GetAsync(u => u.FileName.Equals(request.FileViewModel.FileName)));


        return Success(result);
    }
}
