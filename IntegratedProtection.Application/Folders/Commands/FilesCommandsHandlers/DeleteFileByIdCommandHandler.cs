namespace IntegratedProtection.Application.Folders.Commands.FilesCommandsHandlers;

#region MyRegion
//public class DeleteFileByIdCommandHandler :
//    ResponseHandler,
//    IRequestHandler<DeleteFileByIdCommand, Response<GetFileViewModel>>
//{
//    private readonly IFileHelper _fileHelper;

//    public DeleteFileByIdCommandHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
//    {
//        _fileHelper = fileHelper;
//    }

//    public async Task<Response<GetFileViewModel>>
//        Handle(DeleteFileByIdCommand request, CancellationToken cancellationToken)
//    {
//        if (string.IsNullOrEmpty(request.Id) || string.IsNullOrWhiteSpace(request.Id))
//            return BadRequest<GetFileViewModel>("id is required !");

//        if (!await _context.UploadedFiles.IsExist(f => f.Id.Equals(request.Id)))
//            return NotFound<GetFileViewModel>("not found !");

//        var model = await _context.UploadedFiles.GetAsync(f => f.Id.Equals(request.Id));

//        _fileHelper.DeleteFile(model.FileFullPath);

//        await _context.UploadedFiles.DeleteAsync(model);
//        try
//        {
//            await _context.SaveChangesAsync();
//        }
//        catch (Exception)
//        {
//            return BadRequest<GetFileViewModel>("internal server error !");
//        }

//        return Delete<GetFileViewModel>();
//    }
//} 
#endregion
