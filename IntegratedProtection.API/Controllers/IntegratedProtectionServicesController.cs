using IntegratedProtection.Application.Folders.Queries.FilesQueries;

namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class IntegratedProtectionServicesController : IntegratedProtectionController
{
    public IntegratedProtectionServicesController(IMediator mediator) : base(mediator) { }

    [HttpGet, ActionName(nameof(CarByPlate))]
    public async Task<IActionResult> CarByPlate(string letters, string number)
    {
        var response = await _mediator.Send(new GetCarByPlateQuery(letters, number));

        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(CardBySSN))]
    public async Task<IActionResult> CardBySSN([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new GetCardBySSNQuery(SSN));
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(CriminalBySSN))]
    public async Task<IActionResult> CriminalBySSN([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new GetCriminalBySSNQuery(SSN));
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(DriverBySSN))]
    public async Task<IActionResult> DriverBySSN([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new GetDriverBySSNQuery(SSN));
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(PersonBySSN))]
    public async Task<IActionResult> PersonBySSN([FromQuery] string SSN)
    {
        var response =
            await _mediator.Send(new GetPersonBySSNQuery(SSN));
        return NewResult(response);
    }

    [HttpGet, ActionName(nameof(StolenCarByPlate))]
    public async Task<IActionResult> StolenCarByPlate(string number, string letters)
    {
        var response = await _mediator.Send(new GetStolenCarWithTrafficOfficerQuery(number, letters));
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
}
