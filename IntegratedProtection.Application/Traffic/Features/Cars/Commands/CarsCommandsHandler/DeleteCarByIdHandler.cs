using IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommands;

namespace IntegratedProtection.Application.Traffic.Features.Cars.Commands.CarsCommandsHandler;
#region Put Car Handlers

#endregion


#region Delete Car Handlers
public sealed class DeleteCarByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteCarByIdCommand, Response<GetCarViewModel>>
{
    public DeleteCarByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCarViewModel>> Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetCarViewModel>($"id is required !");

        if (!await _context.Cars.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetCarViewModel>($"car with this id:{request.Id} not found !");

        await _context.Cars.ExecuteDeleteAsync(c => c.Id.Equals(request.Id));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return BadRequest<GetCarViewModel>("Internal server error ");
        }

        return Delete<GetCarViewModel>("Deleted car success !");
    }
}
#endregion

