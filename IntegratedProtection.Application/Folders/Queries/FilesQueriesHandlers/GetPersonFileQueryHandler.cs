namespace IntegratedProtection.Application.Folders.Queries.FilesQueriesHandlers;
//public class GetPersonFileQueryHandler :
//    ResponseHandler,
//    IRequestHandler<GetPersonFileQuery, Response<GetFileViewModel>>
//{
//    private readonly IFileHelper _fileHelper;

//    public GetPersonFileQueryHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
//    {
//        _fileHelper = fileHelper;
//    }

//    public async Task<Response<GetFileViewModel>>
//        Handle(GetPersonFileQuery request, CancellationToken cancellationToken)
//    {
//        if (!await _context.UploadedFiles.IsExist(f => f.IsPersonFile))
//            return NotFound<GetFileViewModel>("no file founded !");

//        var viewModel =
//            _mapper.Map<GetFileViewModel>(await _context.UploadedFiles.GetAsync(f => f.IsPersonFile));

//        viewModel.Base64String = _fileHelper.ReadFileAsBase64(viewModel.FileFullPath);

//        return Success(viewModel);
//    }
//}
