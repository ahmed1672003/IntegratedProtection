using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Queries.FilesQueries;
public record GetFileCarQuery(string WebRootPath) : IRequest<Response<GetFileViewModel>>;

