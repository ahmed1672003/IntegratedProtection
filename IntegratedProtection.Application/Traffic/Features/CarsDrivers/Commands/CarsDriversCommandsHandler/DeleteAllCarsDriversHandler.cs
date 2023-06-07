using IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommands;

namespace IntegratedProtection.Application.Traffic.Features.CarsDrivers.Commands.CarsDriversCommandsHandler;

#region Delete

public sealed class DeleteAllCarsDriversHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCarsDriversCommand, Response<GetCarDriverViewModel>>
{
    public DeleteAllCarsDriversHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarDriverViewModel>>
        Handle(DeleteAllCarsDriversCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.CarsDrivers.IsExist())
            return NotFound<GetCarDriverViewModel>("no cars drivers founded !");

        await _context.CarsDrivers.ExecuteDeleteAsync();

        return Delete<GetCarDriverViewModel>("deleted all cars drivers success !");
    }
}
#endregion

