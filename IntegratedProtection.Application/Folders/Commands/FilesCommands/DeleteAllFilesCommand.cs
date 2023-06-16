using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommands;
public record DeleteAllFilesCommand(string WebRootPath) : IRequest<Response<GetFileViewModel>>;