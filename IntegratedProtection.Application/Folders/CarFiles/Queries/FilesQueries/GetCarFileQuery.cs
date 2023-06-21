using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.CarFiles.Queries.FilesQueries;
public record GetCarFileQuery() : IRequest<Response<GetFileViewModel>>;

