using IntegratedProtection.Application.Folders.PerosnFiles.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Queries.FilesQueriesHandlers;
public class GetPersonFileQueryHandler :
    ResponseHandler,
    IRequestHandler<GetPersonFileQuery, Response<GetFileViewModel>>
{
    public GetPersonFileQueryHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetFileViewModel>>
        Handle(GetPersonFileQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.PersonFiles.IsExist())
            return NotFound<GetFileViewModel>("files not founded !");

        var viewModel = _mapper.Map<GetFileViewModel>(
            await _context.PersonFiles.GetAsync(f => f.Mode == 1));

        return Success(viewModel);
    }
}