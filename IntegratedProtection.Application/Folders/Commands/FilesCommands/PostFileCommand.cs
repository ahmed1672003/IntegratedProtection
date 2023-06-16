using IntegratedProtection.Application.Folders.ViewModels;
namespace IntegratedProtection.Application.Folders.Commands.FilesCommands;
public record PostFileCommand(PostFileViewModel FileViewModel, string WebRootPath) : IRequest<Response<string>>;
