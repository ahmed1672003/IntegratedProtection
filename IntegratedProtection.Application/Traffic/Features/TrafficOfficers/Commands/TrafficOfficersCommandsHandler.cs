namespace IntegratedProtection.Application.Traffic.Features.TrafficOfficers.Commands;

#region Post TrafficOfficer Handler
public sealed class PostTrafficOfficerHandler :
    ResponseHandler,
    IRequestHandler<PostTrafficOfficerCommand, Response<GetTrafficOfficerViewModel>>
{
    public PostTrafficOfficerHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(PostTrafficOfficerCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TrafficOfficer>(request.ViewModel);
        await _context.TrafficOfficers.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetTrafficOfficerViewModel>("Internal server error !");
        }

        var resultModel =
            await (await _context.TrafficOfficers.GetAllAsync()).OrderBy(e => e.Id)
            .LastOrDefaultAsync();

        var resultViewModel = _mapper.Map<GetTrafficOfficerViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion

#region Put TrafficOfficer Handler
public sealed class PutTrafficOfficerHandler :
    ResponseHandler,
    IRequestHandler<PutTrafficOfficerCommand, Response<GetTrafficOfficerViewModel>>
{
    public PutTrafficOfficerHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetTrafficOfficerViewModel>>
        Handle(PutTrafficOfficerCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.Id.Equals(null))
            return BadRequest<GetTrafficOfficerViewModel>("id is required !");

        if (!await _context.TrafficOfficers.IsExist(t => t.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetTrafficOfficerViewModel>($"Traffic officer with this id: {request.ViewModel.Id} not found !");

        var model = _mapper.Map<TrafficOfficer>(request.ViewModel);

        await _context.TrafficOfficers.UpdateAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetTrafficOfficerViewModel>("Internal server error !");
        }
        var resultModel =
            await _context.TrafficOfficers.GetAsync(t => t.Id.Equals(request.ViewModel.Id));

        var resultViewModel = _mapper.Map<GetTrafficOfficerViewModel>(resultModel);

        return Success(resultViewModel, message: "update traffic officer success !");
    }
}
#endregion

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

