using IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommandsHandler;
#region Delete
public sealed class DeleteStolenCarHandler :
    ResponseHandler,
    IRequestHandler<DeleteStolenCarCommand, Response<GetStolenCarViewModel>>
{
    public DeleteStolenCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetStolenCarViewModel>>
        Handle(DeleteStolenCarCommand request, CancellationToken cancellationToken)
    {
        if (request.CarId.Equals(null) || request.TrafficOfficerId.Equals(null))
            return BadRequest<GetStolenCarViewModel>("CarId & TrafficOfficerId are required !");

        if (!
            await _context.StolenCars.IsExist(s => s.CarId.Equals(request.CarId) &&
            s.TrafficOfficerId.Equals(request.TrafficOfficerId)))
            return NotFound<GetStolenCarViewModel>
                ($"stolen car with this carId:{request.CarId} & trafficOfficerId:{request.TrafficOfficerId}");

        await _context.StolenCars.ExecuteDeleteAsync(s =>
        s.CarId.Equals(request.CarId) &&
        s.TrafficOfficerId.Equals(request.TrafficOfficerId));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetStolenCarViewModel>("Internal server error !");
        }

        return Delete<GetStolenCarViewModel>("deleted successfully! ");
    }
}
#endregion
