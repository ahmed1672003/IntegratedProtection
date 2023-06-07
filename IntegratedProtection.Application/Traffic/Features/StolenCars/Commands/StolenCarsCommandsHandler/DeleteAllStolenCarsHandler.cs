using IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands.StolenCarsCommandsHandler;

#region Delete

public sealed class DeleteAllStolenCarsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllStolenCarsCommand, Response<GetStolenCarViewModel>>
{
    public DeleteAllStolenCarsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetStolenCarViewModel>>
        Handle(DeleteAllStolenCarsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.StolenCars.IsExist())
            return NotFound<GetStolenCarViewModel>("mo stolen cars founded !");
        await _context.StolenCars.ExecuteDeleteAsync();

        return Delete<GetStolenCarViewModel>("deleted all stolen cars success !");
    }
}
#endregion
