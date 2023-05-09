using IntegratedProtection.Application.Traffic.Features.Drivers.Commands;
using IntegratedProtection.Application.Traffic.Features.Drivers.Queries;

namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DriverController : IntegratedProtectionController
{
    public DriverController(IMediator mediator) : base(mediator)
    {
    }

    #region => POST

    [HttpPost, ActionName("Post")]
    public async Task<IActionResult> CreateDriver([FromForm] PostDriverViewModel viewModel)
    {
        var response = await _mediator.Send(new PostDriverCommand(viewModel));
        return NewResult(response);
    }
    #endregion

    #region => PUT

    [HttpPut, ActionName("Put")]
    public async Task<IActionResult> UpdateDriver([FromForm] PutDriverViewModel viewModel)
    {
        var response = await _mediator.Send(new PutDriverCommand(viewModel));
        return NewResult(response);
    }

    #endregion

    #region => GET

    [HttpGet("{id:int}"), ActionName("GetById")]
    public async Task<IActionResult> GetById(int? id)
    {
        var response = await _mediator.Send(new GetDriverByIdQuery(id));
        return NewResult(response);
    }

    [HttpGet, ActionName("GetBySSN")]
    public async Task<IActionResult> GetById([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new GetDriverBySSNQuery(SSN));
        return NewResult(response);
    }

    [HttpGet, ActionName("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllDriversQuery());
        return NewResult(response);
    }
    #endregion

    #region => DELETE

    [HttpDelete("{id:int}"), ActionName("DeleteById")]
    public async Task<IActionResult> DeleteById(int? id)
    {
        var response = await _mediator.Send(new DeleteDriverByIdCommand(id));
        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteBySSN")]
    public async Task<IActionResult> DeleteBySSN([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new DeleteDriverBySSNCommand(SSN));
        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteAll")]
    public async Task<IActionResult> DeleyeAll()
    {
        var response = await _mediator.Send(new DeleteAllDriversCommand());
        return NewResult(response);
    }
    #endregion
}
