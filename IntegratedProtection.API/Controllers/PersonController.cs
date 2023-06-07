namespace IntegratedProtection.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PersonController : IntegratedProtectionController
{
    public PersonController(IMediator mediator) : base(mediator)
    {
    }

    #region  => POST
    [HttpPost, ActionName("Post")]
    public async Task<IActionResult> CreatePerson([FromForm] PostPersonViewModel viewModel)
    {
        var response =
            await _mediator.Send(new PostPersonCommand(viewModel));

        return NewResult(response);
    }
    #endregion

    #region => PUT
    [HttpPut, ActionName("Put")]
    public async Task<IActionResult> UpdatePerson([FromForm] PutPersonViewModel viewModel)
    {
        var response =
            await _mediator.Send(new PutPersonCommand(viewModel));

        return NewResult(response);
    }
    #endregion

    #region => GET 

    [HttpGet("{id:int}"), ActionName("GetById")]
    public async Task<IActionResult> GetPersonById(int id)
    {
        var response = await _mediator.Send(new GetPersonByIdQuery(id));
        return NewResult(response);
    }

    [HttpGet, ActionName("GetBySSN")]
    public async Task<IActionResult> GetPersonBySSN([FromQuery] string SSN)
    {
        var response =
            await _mediator.Send(new GetPersonBySSNQuery(SSN));
        return NewResult(response);
    }

    [HttpGet, ActionName("GetAll")]
    public async Task<IActionResult> GetAllPersons()
    {
        var response = await _mediator.Send(new GetAllPersonsQuery());
        return NewResult(response);
    }

    #region Get All Persons With CompileQuery

    //[HttpGet, ActionName("GetAllWithCompileQuery")]
    //public async Task<IActionResult> GetAllPersonsWithCompileQuery()
    //{
    //    var response = await _mediator.Send(new GetAllPersonsQuery());
    //    return NewResult(response);
    //}
    #endregion

    [HttpGet("{id:int}"), ActionName("GetByIdWithCard")]
    public async Task<IActionResult> GetPersonByIdWithCard(int? id)
    {
        var response =
            await _mediator.Send(new GetPersonByIdWithCardQuery(id));

        return NewResult(response);
    }

    [HttpGet, ActionName("GetBySSNWithCard")]
    public async Task<IActionResult> GetPersonBySSNWithCard([FromQuery] string SSN)
    {
        var response =
            await _mediator.Send(new GetPersonBySSNWithCardQuery(SSN));
        return NewResult(response);
    }


    #endregion

    #region => Delete

    [HttpDelete("{id:int}"), ActionName("DeleteById"),]
    public async Task<IActionResult> DeleteById(int id)
    {
        var response = await _mediator.Send(new DeletePersonByIdCommand(id));
        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteBySSN")]
    public async Task<IActionResult> DeleteBySSN([FromQuery] string SSN)
    {
        var response = await _mediator.Send(new DeletePersonBySSNCommand(SSN));

        return NewResult(response);
    }

    [HttpDelete, ActionName("DeleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        var response = await _mediator.Send(new DeleteAllPersonsCommand());
        return NewResult(response);
    }
    #endregion
}
