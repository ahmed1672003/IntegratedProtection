using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Queries.FilesQueries;
public record GetPersonFileQuery(string WebRootPath) : IRequest<Response<GetFileViewModel>>;

