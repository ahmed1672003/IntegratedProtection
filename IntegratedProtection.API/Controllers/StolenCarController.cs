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

    #region GET 
    [HttpGet, ActionName("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllStolenCarsQuery());

        return NewResult(response);
    }
    #endregion

    #region DELETE

    [HttpDelete, ActionName("Delete")]
    public async Task<IActionResult> Delete(int? carId, int? trafficOfficerId)
    {
        var response =
            await _mediator.Send(new DeleteStolenCarCommand(carId, trafficOfficerId));
        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        var response = await _mediator.Send(new DeleteAllStolenCarsCommand());
        return NewResult(response);
    }
    #endregion
}
