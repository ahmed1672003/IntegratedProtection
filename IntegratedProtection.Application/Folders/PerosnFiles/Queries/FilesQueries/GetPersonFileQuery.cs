using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Queries.FilesQueries;
public record GetPersonFileQuery() : IRequest<Response<GetFileViewModel>>;

