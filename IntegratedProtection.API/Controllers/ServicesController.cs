namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ServicesController : IntegratedProtectionController
{
    public ServicesController(IMediator mediator) : base(mediator) { }

}
