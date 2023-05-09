namespace IntegratedProtection.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : IntegratedProtectionController
    {
        public CardController(IMediator mediator) : base(mediator)
        {
        }


        #region => POST
        [HttpPost, ActionName("Post")]
        public async Task<IActionResult> CreateCard([FromForm] PostCardViewModel viewModel)
        {
            var response =
                await _mediator.Send(new PostCardCommand(viewModel));

            return NewResult(response);
        }
        #endregion

        #region => PUT
        [HttpPut, ActionName("Put")]
        public async Task<IActionResult> UpdateCard([FromForm] PutCardViewModel viewModel)
        {
            var response = await _mediator.Send(new PutCardCommand(viewModel));
            return NewResult(response);
        }

        #endregion

        #region => GET

        [HttpGet, ActionName("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCardsQuery());
            return NewResult(response);
        }

        [HttpGet("{id:int}"), ActionName("GetById")]
        public async Task<IActionResult> GetById(int? id)
        {
            var response = await _mediator.Send(new GetCardByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet, ActionName("GetBySSN")]
        public async Task<IActionResult> GetBySSN([FromQuery] string SSN)
        {
            var response = await _mediator.Send(new GetCardBySSNQuery(SSN));
            return NewResult(response);
        }

        [HttpGet("{id:int}"), ActionName("GetByIdWithPerson")]
        public async Task<IActionResult> GetByIdWithPerson(int? id)
        {
            var response = await _mediator.Send(new GetCardByIdWithPersonQuery(id));

            return NewResult(response);
        }

        [HttpGet, ActionName("GetBySSNWithPerson")]
        public async Task<IActionResult> GetBySSNWithPerson([FromQuery] string SSN)
        {
            var response = await _mediator.Send(new GetCardBySSNWithPersonQuery(SSN));

            return NewResult(response);
        }


        #endregion

        #region => Delete 
        [HttpDelete("{id:int}"), ActionName("DeleteById")]
        public async Task<IActionResult> DeleteById(int? id)
        {
            var response = await _mediator.Send(new DeleteCardByIdCommand(id));
            return NewResult(response);
        }

        [HttpDelete, ActionName("DeleteBySSN")]
        public async Task<IActionResult> DeleteById([FromQuery] string SSN)
        {
            var response = await _mediator.Send(new DeleteCardBySSNCommand(SSN));
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
}
