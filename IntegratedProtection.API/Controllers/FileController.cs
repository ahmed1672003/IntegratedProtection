using IntegratedProtection.Application.Folders.CarFiles.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.CarFiles.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.PerosnFiles.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.PerosnFiles.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FileController : IntegratedProtectionController
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileController(IMediator mediator, IWebHostEnvironment environment) : base(mediator) =>
        _webHostEnvironment = environment;
    #region Post

    [HttpPost, ActionName(nameof(PostCarFile))]
    public async Task<IActionResult> PostCarFile([FromForm] PostFileViewModel viewModel)
    {
        var response = await _mediator.Send(new PostCarFileCommand(viewModel));
        return NewResult(response);
    }

    [HttpPost, ActionName(nameof(PostPersonFile))]
    public async Task<IActionResult> PostPersonFile([FromForm] PostFileViewModel viewModel)
    {
        var response = await _mediator.Send(new PostCarFileCommand(viewModel));
        return NewResult(response);
    }
    #endregion

    #region Get
    [HttpGet, ActionName(nameof(GetCarFile))]
    public async Task<IActionResult> GetCarFile()
    {
        var response = await _mediator.Send(new GetCarFileQuery());
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(GetPersonFile))]
    public async Task<IActionResult> GetPersonFile()
    {
        var response = await _mediator.Send(new GetPersonFileQuery());
        return NewResult(response);
    }
    #endregion

    #region Delete
    [HttpDelete, ActionName(nameof(DeleteAllCarFiles))]
    public async Task<IActionResult> DeleteAllCarFiles()
    {
        var response = await _mediator.Send(new DeleteAllCarFilesCommand());
        return NewResult(response);
    }

    [HttpDelete, ActionName(nameof(DeleteAllPersonFiles))]
    public async Task<IActionResult> DeleteAllPersonFiles()
    {
        var response = await _mediator.Send(new DeleteAllPersonsFilesCommand());
        return NewResult(response);
    }
    #endregion
}
