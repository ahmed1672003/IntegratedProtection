namespace IntegratedProtection.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CriminalController : IntegratedProtectionController
{
    public CriminalController(IMediator mediator) : base(mediator) { }
    #region POST
    [HttpPost, ActionName("Post")]
    public async Task<IActionResult> CreateCriminal([FromForm] PostCriminalViewModel viewModel)
    {
        var response =
            await _mediator.Send(new PostCriminalCommand(viewModel));
        return NewResult(response);
    }
    #endregion
    #region PUT
    [HttpPut, ActionName("Put")]
    public async Task<IActionResult> UpdateCriminal([FromForm] PutCriminalViewModel viewModel)
    {
        var response = await _mediator.Send(new PutCriminalCommand(viewModel));
        return NewResult(response);
    }
    #endregion

    #region GET
    [HttpGet("{id:int}"), ActionName("GetById")]
    public async Task<IActionResult> GetById(int? id)
    {
        var response = await _mediator.Send(new GetCriminalByIdQuery(id));
        return NewResult(response);
    }

    [HttpGet, ActionName("GetBySSN")]
    public async Task<IActionResult> GetBySSN([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new GetCriminalBySSNQuery(SSN));
        return NewResult(response);
    }
    [HttpGet, ActionName("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllCriminalsQuery());
        return NewResult(response);
    }

    #endregion

    #region DELETE
    [HttpDelete("{id:int}"), ActionName("DeleteById")]
    public async Task<IActionResult> DeleteById(int? id)
    {
        var response = await _mediator.Send(new DeleteCriminalByIdCommand(id));
        return NewResult(response);
    }
    [HttpDelete, ActionName("DeleteBySSN")]
    public async Task<IActionResult> DeleteBySSN(string SSN)
    {
        var response = await _mediator.Send(new DeleteCriminalBySSNCommand(SSN));
        return NewResult(response);
    }
    [HttpDelete, ActionName("DeleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        var response = await _mediator.Send(new DeleteAllCriminalsCommand());
        return NewResult(response);
    }

    #endregion
}
