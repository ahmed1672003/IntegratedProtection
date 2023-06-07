

namespace IntegratedProtection.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarDriverController : IntegratedProtectionController
    {
        public CarDriverController(IMediator mediator) : base(mediator)
        {
        }


        #region POST
        [HttpPost, ActionName("Post")]
        public async Task<IActionResult> CreateCarDriver([FromForm] PostCarDriverViewModel viewModel)
        {
            var response = await _mediator.Send(new PostCarDriverCommand(viewModel));
            return NewResult(response);
        }
        #endregion

        #region GET
        [HttpGet, ActionName("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCarsQuery());
            return NewResult(response);
        }

        #endregion

        #region Delete
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> Delete(int? carId, int? driverId)
        {
            var response =
                await _mediator.Send(new DeleteCarDriverCommand(carId, driverId));
            return NewResult(response);
        }


        [HttpDelete, ActionName("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            var response = await _mediator.Send(new DeleteAllCarsDriversCommand());
            return NewResult(response);
        }
        #endregion
    }
}
