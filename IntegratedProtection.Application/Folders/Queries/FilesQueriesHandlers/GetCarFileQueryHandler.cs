using IntegratedProtection.Application.Folders.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Queries.FilesQueriesHandlers;
public class GetCarFileQueryHandler :
    ResponseHandler,
    IRequestHandler<GetFileCarQuery, Response<GetFileViewModel>>
{
    private readonly IFileHelper _fileHelper;
    public GetCarFileQueryHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<GetFileViewModel>>
        Handle(GetFileCarQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.UploadedFiles.IsExist(f => !f.IsPersonsFile))
            return NotFound<GetFileViewModel>("files not founded !");

        var viewModel = _mapper.Map<GetFileViewModel>(
            await _context.UploadedFiles.GetAsync(f => !f.IsPersonsFile));

        return Success(viewModel);
    }
}