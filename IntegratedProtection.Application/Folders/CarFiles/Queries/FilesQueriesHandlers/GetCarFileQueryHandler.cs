using IntegratedProtection.Application.Folders.CarFiles.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.CarFiles.Queries.FilesQueriesHandlers;
public class GetCarFileQueryHandler :
    ResponseHandler,
    IRequestHandler<GetCarFileQuery, Response<GetFileViewModel>>
{
    public GetCarFileQueryHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetFileViewModel>>
        Handle(GetCarFileQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.CarFiles.IsExist())
            return NotFound<GetFileViewModel>("not found");

        var viewModel = _mapper.Map<GetFileViewModel>(
            await _context.CarFiles.GetAsync(f => f.Mode == 0));

        return Success(viewModel);
    }
}
