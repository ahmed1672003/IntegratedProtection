using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
public record PostPersonFileCommand(PostFileViewModel ViewModel) : IRequest<Response<string>>;
