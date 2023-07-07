using System.Net;

using IntegratedProtection.Application.Bases;
namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntegratedProtectionController : Controller
{
    protected readonly IMediator _mediator;
    public IntegratedProtectionController(IMediator mediator)
    {
        _mediator = mediator;

    }
    #region Actions
    public ObjectResult NewResult<TData>(Response<TData> response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(response);
            case HttpStatusCode.Created:
                return new CreatedResult(string.Empty, response);
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);
            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);
            case HttpStatusCode.Accepted:
                return new AcceptedResult(string.Empty, response);
            case HttpStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(response);
            default:
                return new BadRequestObjectResult(response);
        }
    }
    #endregion
}
