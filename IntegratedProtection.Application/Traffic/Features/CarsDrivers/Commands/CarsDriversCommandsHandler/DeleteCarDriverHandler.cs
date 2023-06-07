using IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommandsHandler;
#region POST
#endregion


#region Delete
public sealed class DeleteCarDriverHandler :
    ResponseHandler,
    IRequestHandler<DeleteCarDriverCommand, Response<GetCarDriverViewModel>>
{
    public DeleteCarDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarDriverViewModel>>
        Handle(DeleteCarDriverCommand request, CancellationToken cancellationToken)
    {
        if (request.CarId.Equals(null) || request.DriverId.Equals(null))
            return BadRequest<GetCarDriverViewModel>($"CarId & DriverId are required !");

        if (!await _context.CarsDrivers.IsExist(
            cd => cd.CarId.Equals(request.CarId) &&
            cd.DriverId.Equals(request.DriverId)))
            return NotFound<GetCarDriverViewModel>
                ($"car driver with carId: {request.CarId} & driverId: {request.DriverId} are not founded !");

        await _context.CarsDrivers.ExecuteDeleteAsync(
            cd => cd.CarId.Equals(request.CarId) &&
            cd.DriverId.Equals(request.DriverId));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCarDriverViewModel>("Internal server error !");
        }

        return Delete<GetCarDriverViewModel>("deleted success !");
    }
}
#endregion

