using IntegratedProtection.Application.Folders.CarFiles.Queries.FilesQueries;
using IntegratedProtection.Application.Folders.PerosnFiles.Queries.FilesQueries;

namespace IntegratedProtection.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class IntegratedProtectionServicesController : IntegratedProtectionController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public IntegratedProtectionServicesController(IMediator mediator, IHttpClientFactory httpClientFactory = null) : base(mediator)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet, ActionName(nameof(CarByPlate))]
    public async Task<IActionResult> CarByPlate(string plate)
    {
        var response =
            await _mediator.Send(new GetCarByPlateQuery(plate));
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
    public async Task<IActionResult> StolenCarByPlate(string plate)
    {
        var response = await _mediator.Send(new GetStolenCarByPlateQuery(plate));
        return NewResult(response);
    }
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
}
