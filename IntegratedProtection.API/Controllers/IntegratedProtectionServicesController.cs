namespace IntegratedProtection.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IntegratedProtectionServicesController : IntegratedProtectionController
    {
        public IntegratedProtectionServicesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> PersonData([FromQuery] string SSN)
        {
            var response = await _mediator
                .Send(new GetPersonDataQuery(SSN));
            return NewResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> CarData([FromQuery] string numbers, [FromQuery] string letters)
        {
            var response = await _mediator.Send(new GetCarDataQuery(numbers, letters));
            return NewResult(response);
        }
    }
}
