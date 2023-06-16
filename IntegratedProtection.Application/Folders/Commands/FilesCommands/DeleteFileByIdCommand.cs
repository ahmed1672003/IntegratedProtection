using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommands;
public record DeleteFileByIdCommand(string Id) : IRequest<Response<GetFileViewModel>>;

