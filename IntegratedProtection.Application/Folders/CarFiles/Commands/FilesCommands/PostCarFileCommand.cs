using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.CarFiles.Commands.FilesCommands;
public record PostCarFileCommand(PostFileViewModel ViewModel) : IRequest<Response<GetFileViewModel>>;

