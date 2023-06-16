using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.Commands.FilesCommands;
public record DeleteAllFilesCommand() : IRequest<Response<GetFileViewModel>>;