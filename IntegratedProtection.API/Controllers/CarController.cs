

namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CarController : IntegratedProtectionController
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CarController(IMediator mediator) : base(mediator)
    {
    }

    #region => POST 

    [HttpPost, ActionName("Post")]
    public async Task<IActionResult> CreateCar([FromForm] PostCarViewModel viewModel)
    {
        var response = await _mediator.Send(new PostCarCommand(viewModel));
        return NewResult(response);
    }
    #endregion

    #region => PUT
    [HttpPut, ActionName("Put")]
    public async Task<IActionResult> UpdateCar([FromForm] PutCarViewModel viewModel)
    {
        var response = await _mediator.Send(new PutCarCommand(viewModel));
        return NewResult(response);
    }

    #endregion

    #region => GET

    [HttpGet, ActionName("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllCarsQuery());

        return NewResult(response);
    }


    [HttpGet, ActionName("GetById")]
    public async Task<IActionResult> GetById(int? id)
    {
        var response = await _mediator.Send(new GetCarByIdQuery(id));

        return NewResult(response);
    }

    [HttpGet, ActionName("GetByPlate")]
    public async Task<IActionResult> GetByPlate(string letters, string number)
    {
        var response = await _mediator.Send(new GetCarByPlateQuery(letters, number));

        return NewResult(response);
    }


    #endregion

    #region => DELETE
    [HttpDelete, ActionName("DeleteById")]
    public async Task<IActionResult> DeleteById(int? id)
    {
        var response = await _mediator.Send(new DeleteCarByIdCommand(id));

        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteByPlate")]
    public async Task<IActionResult> DeleteByPlate(string letters, string number)
    {
        var response =
            await _mediator.Send(new DeleteCarByPlateCommand(letters, number));

        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        var response = await _mediator.Send(new DeleteAllCarsCommand());

        return NewResult(response);
    }
    #endregion
}
