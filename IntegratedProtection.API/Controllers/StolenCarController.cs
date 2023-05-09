using IntegratedProtection.Application.Traffic.Features.StolenCars.Commands;

namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class StolenCarController : IntegratedProtectionController
{
    public StolenCarController(IMediator mediator) : base(mediator)
    {
    }

    #region POST

    [HttpPost, ActionName("ReportAboutStolenCar")]
    public async Task<IActionResult> ReportAboutStolenCar([FromForm] PostStolenCarViewModel viewModel)
    {
        var response = await _mediator.Send(new PostStolenCarCommand(viewModel));

        return NewResult(response);
    }

    #endregion
}
