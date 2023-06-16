using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommandsHandlers;




public class PostFileCommandHandler :
    ResponseHandler,
    IRequestHandler<PostFileCommand, Response<string>>
{
    private readonly IFileHelper _fileHelper;
    public PostFileCommandHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<string>>
        Handle(PostFileCommand request, CancellationToken cancellationToken)
    {
        if (request.FileViewModel.SRC is null)
            return BadRequest<string>("src field is required !");

        var model = _mapper.Map<UploadedFile>(request.FileViewModel);

        await _context.UploadedFiles.AddAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<string>("internal sever error !");
        }

        return Success<string>(data: null);
    }
}
