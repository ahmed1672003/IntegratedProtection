using IntegratedProtection.Application.Folders.CarFiles.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.ViewModels;
using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Application.Folders.CarFiles.Commands.FilesCommandsHandlers;
public class PostCarFileHandler :
    ResponseHandler,
    IRequestHandler<PostCarFileCommand, Response<GetFileViewModel>>
{
    public PostCarFileHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetFileViewModel>>
        Handle(PostCarFileCommand request, CancellationToken cancellationToken)
    {

        if (request.ViewModel.SRC is null || request.ViewModel.FileName is null)
            return BadRequest<GetFileViewModel>();

        if (!await _context.CarFiles.IsExist(f => f.FileName.Equals(request.ViewModel.FileName)))
            return BadRequest<GetFileViewModel>(message: "file founded");

        var model = _mapper.Map<CarFile>(request.ViewModel);

        try
        {
            await _context.CarFiles.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetFileViewModel>("Internal server error !");
        }

        return Success<GetFileViewModel>(null);
    }
}
