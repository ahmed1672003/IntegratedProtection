using IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommandsHandlers;




public class PostPersonFileCommandHandler :
    ResponseHandler,
    IRequestHandler<PostPersonFileCommand, Response<string>>
{
    private readonly IFileHelper _fileHelper;
    public PostPersonFileCommandHandler
        (IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<string>>
        Handle(PostPersonFileCommand request, CancellationToken cancellationToken)
    {
        if (request.FileViewModel.SRC is null || request.FileViewModel.FileName is null)
            return BadRequest<string>("src field and fileNAme are required !");

        var model = _mapper.Map<PersonFile>(request.FileViewModel);

        await _context.PersonFiles.AddAsync(model);
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
