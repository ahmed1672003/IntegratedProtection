using IntegratedProtection.Application.Constants;
using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Core.FilesEntity;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommandsHandlers;


#region MyRegion
//public class PostFileCommandHandler :
//    ResponseHandler,
//    IRequestHandler<PostFileCommand, Response<PostFileViewModel>>
//{
//    public PostFileCommandHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

//    public async Task<Response<PostFileViewModel>>
//        Handle(PostFileCommand request, CancellationToken cancellationToken)
//    {
//        if (string.IsNullOrEmpty(request.FileViewModel.FileFullPath) || string.IsNullOrWhiteSpace(request.FileViewModel.FileFullPath))
//            return BadRequest<PostFileViewModel>(message: "File field is required !");

//        var uploadedFile = _mapper.Map<UploadedFile>(request.FileViewModel);
//        await _context.UploadedFiles.AddAsync(uploadedFile);
//        try
//        {
//            await _context.SaveChangesAsync();
//        }
//        catch (Exception)
//        {
//            return BadRequest<PostFileViewModel>("Internal server error !");
//        }

//        var result = _mapper.Map<PostFileViewModel>(
//            await _context.UploadedFiles.GetAsync(u => u.FileFullPath.Equals(request.FileViewModel.FileFullPath)));
//        return Success(result);
//    }
//} 
#endregion

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
        if (request.FileViewModel.file is null)
            return BadRequest<string>("file field is required !");

        var model = _mapper.Map<UploadedFile>(request.FileViewModel);

        var path = Path.Combine(request.WebRootPath, Stocks.Videos, model.StorageFileName!);

        await _fileHelper.ToStorage(request.FileViewModel.file, path);

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
