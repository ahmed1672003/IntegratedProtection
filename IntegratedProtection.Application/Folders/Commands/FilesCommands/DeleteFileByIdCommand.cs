using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommands;
public record DeleteFileByIdCommand(string Id, string WebRootPath) : IRequest<Response<GetFileViewModel>>;

