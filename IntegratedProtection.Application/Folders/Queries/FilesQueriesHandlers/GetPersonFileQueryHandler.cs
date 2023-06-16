using IntegratedProtection.Application.Constants;
using IntegratedProtection.Application.Folders.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Queries.FilesQueriesHandlers;
public class GetPersonFileQueryHandler :
    ResponseHandler,
    IRequestHandler<GetPersonFileQuery, Response<GetFileViewModel>>
{
    private readonly IFileHelper _fileHelper;

    public GetPersonFileQueryHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<GetFileViewModel>>
        Handle(GetPersonFileQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.UploadedFiles.IsExist(f => f.IsPersonsFile))
            return NotFound<GetFileViewModel>("no file founded !");

        var viewModel =
            _mapper.Map<GetFileViewModel>(await _context.UploadedFiles.GetAsync(f => f.IsPersonsFile));

        var path = Path.Combine(request.WebRootPath, Stocks.Videos, viewModel.StorageFileName!);


        viewModel.Base64 = await _fileHelper.ReadFileAsBase64(path);

        return Success(viewModel);
    }
}
