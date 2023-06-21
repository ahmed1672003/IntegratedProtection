using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
public record PostPersonFileCommand(PostFileViewModel FileViewModel) : IRequest<Response<string>>;
