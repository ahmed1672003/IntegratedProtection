using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommandsHandler;
#region Delete TrafficOfficer Handler
public sealed class DeleteTrafficOfficerByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteTrafficOfficerByIdCommand, Response<GetTrafficOfficerViewModel>>
{
    public DeleteTrafficOfficerByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(DeleteTrafficOfficerByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetTrafficOfficerViewModel>("id is required !");

        if (!await _context.TrafficOfficers.IsExist(t => t.Id.Equals(request.Id)))
            return NotFound<GetTrafficOfficerViewModel>($"Traffic Officer with this id: {request.Id} not found !");


        await _context.TrafficOfficers.ExecuteDeleteAsync(t => t.Id.Equals(request.Id));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetTrafficOfficerViewModel>("Internal sever error !");
        }

        return Delete<GetTrafficOfficerViewModel>("deleted successfully !");
    }
}
#endregion

