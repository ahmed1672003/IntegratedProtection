using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Queries.FilesQueries;
public record GetFileCarQuery() : IRequest<Response<GetFileViewModel>>;

