using IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommandsHandler;
#region Post Car Handlers
#endregion

#region Put Car Handlers
public sealed class PutCarHandler :
    ResponseHandler,
    IRequestHandler<PutCarCommand, Response<GetCarViewModel>>
{
    public PutCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>>
        Handle(PutCarCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist(c => c.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCarViewModel>($"car with this id:{request.ViewModel.Id} not found !");

        var model = _mapper.Map<Car>(request.ViewModel);
        var resultModel = await _context.Cars.UpdateAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return BadRequest<GetCarViewModel>("Internal server error ");
        }
        var resultViewModel = _mapper.Map<GetCarViewModel>(resultModel);
        return Accepted(resultViewModel, "Updated car success !");
    }
}
#endregion

