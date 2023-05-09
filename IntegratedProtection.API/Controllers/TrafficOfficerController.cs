namespace IntegratedProtection.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TrafficOfficerController : IntegratedProtectionController
{
    public TrafficOfficerController(IMediator mediator) : base(mediator) { }

    #region POST 
    [HttpPost, ActionName("Post")]
    public async Task<IActionResult> CreateTrafficOfficer([FromForm] PostTrafficOfficerViewModel viewModel)
    {
        var response = await _mediator.Send(new PostTrafficOfficerCommand(viewModel));
        return NewResult(response);
    }

    #endregion

    #region PUT

    [HttpPut, ActionName("Put")]
    public async Task<IActionResult> UpdateTrafficOfficer([FromForm] PutTrafficOfficerViewModel viewModel)
    {
        var response = await _mediator.Send(new PutTrafficOfficerCommand(viewModel));

        return NewResult(response);
    }

    #endregion

    #region GET
    [HttpGet("{id:int}"), ActionName("GetById")]
    public async Task<IActionResult> GetById(int? id)
    {
        var response = await _mediator.Send(new GetTrafficOfficerByIdQuery(id));
        return NewResult(response);
    }

    [HttpGet, ActionName("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllTrafficOfficersQuery());
        return NewResult(response);
    }
    #endregion

    #region DELETE
    [HttpDelete("{id:int}"), ActionName("DeleteById")]
    public async Task<IActionResult> DeleteById(int? id)
    {
        var response = await _mediator.Send(new DeleteTrafficOfficerByIdCommand(id));
        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        var response = await _mediator.Send(new DeleteAllTrafficOfficersCommand());

        return NewResult(response);
    }
    #endregion
}
