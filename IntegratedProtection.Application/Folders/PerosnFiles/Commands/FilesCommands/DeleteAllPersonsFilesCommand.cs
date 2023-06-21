using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
public record DeleteAllPersonsFilesCommand() : IRequest<Response<GetFileViewModel>>;