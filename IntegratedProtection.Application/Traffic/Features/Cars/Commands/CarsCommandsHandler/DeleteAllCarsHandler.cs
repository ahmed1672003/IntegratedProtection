using IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommandsHandler;

#region Delete Car Handlers

public sealed class DeleteAllCarsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCarsCommand, Response<GetCarViewModel>>
{
    public DeleteAllCarsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>> Handle(DeleteAllCarsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist())
            return NotFound<GetCarViewModel>("no cars founded !");

        await _context.Cars.ExecuteDeleteAsync();

        return Delete<GetCarViewModel>("deleted all cars success !");
    }
}
#endregion

