using IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommandsHandlers;

public class PostPersonFileCommandHandler :
    ResponseHandler,
    IRequestHandler<PostPersonFileCommand, Response<string>>
{
    public PostPersonFileCommandHandler
        (IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }
    public async Task<Response<string>>
        Handle(PostPersonFileCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.SRC is null || request.ViewModel.FileName is null)
            return BadRequest<string>("src field and fileNAme are required !");

        var model = _mapper.Map<PersonFile>(request.ViewModel);

        await _context.PersonFiles.AddAsync(model);
        try
        {
            var result = await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<string>("internal sever error !");
        }

        return Success<string>(data: null);
    }
}
