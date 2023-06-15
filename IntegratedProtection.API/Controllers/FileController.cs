using IntegratedProtection.API.Extensions;
using IntegratedProtection.Application.Folders.Commands.FilesCommands;
using IntegratedProtection.Application.Folders.ViewModels;

namespace IntegratedProtection.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FileController : IntegratedProtectionController
{
    //private IHostingEnvironment _environment;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileController(IMediator mediator, IWebHostEnvironment environment) : base(mediator) =>
        _webHostEnvironment = environment;

    [HttpPost, ActionName(nameof(Upload))]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var viewModel = new PostFileViewModel()
        {
            FileName = await file.ToStorage(_webHostEnvironment),
        };
        var response = await _mediator.Send(new PostFileCommand(viewModel));
        return NewResult(response);
    }
}
