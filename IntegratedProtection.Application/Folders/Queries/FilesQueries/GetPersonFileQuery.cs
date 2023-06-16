using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Queries.FilesQueries;
public record GetPersonFileQuery() : IRequest<Response<GetFileViewModel>>;

