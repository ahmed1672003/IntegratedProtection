using IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommandsHandler;
#region Delete Car Handlers

public sealed class DeleteCarByPlateHandler :
    ResponseHandler,
    IRequestHandler<DeleteCarByPlateCommand, Response<GetCarViewModel>>
{
    public DeleteCarByPlateHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>> Handle(DeleteCarByPlateCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cars.IsExist(c => c.Letters.Equals(request.Letters) && c.Number.Equals(request.Number)))
            return NotFound<GetCarViewModel>($"car with this letters:{request.Letters} & numbers:{request.Number} not found !");

        await _context.Cars.ExecuteDeleteAsync(c => c.Letters.Equals(request.Letters) && c.Number.Equals(request.Number));

        return Delete<GetCarViewModel>("car deleted success !");
    }
}
#endregion

