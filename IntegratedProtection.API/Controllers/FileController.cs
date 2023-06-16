using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FileController : IntegratedProtectionController
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileController(IMediator mediator, IWebHostEnvironment environment) : base(mediator) =>
        _webHostEnvironment = environment;

    [HttpPost, ActionName(nameof(Upload))]
    public async Task<IActionResult> Upload([FromForm] PostFileViewModel viewModel)
    {
        var response = await _mediator.Send(new PostFileCommand(viewModel));
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(GetCarFile))]
    public async Task<IActionResult> GetCarFile()
    {
        var response = await _mediator.Send(new GetFileCarQuery());
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(GetPersonFile))]
    public async Task<IActionResult> GetPersonFile()
    {
        var response = await _mediator.Send(new GetPersonFileQuery());
        return NewResult(response);
    }

    [HttpDelete, ActionName(nameof(Delete))]
    public async Task<IActionResult> Delete(string id)
    {
        var response =

            await _mediator.Send(new DeleteFileByIdCommand(id));
        return NewResult(response);
    }


    [HttpDelete, ActionName(nameof(DeleteAll))]
    public async Task<IActionResult> DeleteAll()
    {
        var response = await _mediator.Send(new DeleteAllFilesCommand(_webHostEnvironment.WebRootPath));
        return NewResult(response);
    }
}
