using IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommands;

namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands.TrafficOfficersCommandsHandler;

#region Delete TrafficOfficer Handler

public sealed class DeleteAllTrafficOfficersHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllTrafficOfficersCommand, Response<GetTrafficOfficerViewModel>>
{
    public DeleteAllTrafficOfficersHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(DeleteAllTrafficOfficersCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.TrafficOfficers.IsExist())
            return NoContent<GetTrafficOfficerViewModel>();

        await _context.TrafficOfficers.ExecuteDeleteAsync();

        return Delete<GetTrafficOfficerViewModel>("all traffic officers deleted successfully !");
    }
}
#endregion

