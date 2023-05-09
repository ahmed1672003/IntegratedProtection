using Microsoft.EntityFrameworkCore;

namespace IntegratedProtection.Application.Traffic.Features.Drivers.Commands;

#region Post Driver Handlers

public class PostDriverHandler :
    ResponseHandler,
    IRequestHandler<PostDriverCommand, Response<GetDriverViewModel>>
{
    public PostDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>>
        Handle(PostDriverCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Driver>(request.ViewModel);
        await _context.Drivers.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error");
        }

        var resultModel = await (await _context.Drivers.GetAllAsync())
            .OrderBy(e => e.Id).LastOrDefaultAsync();

        var resultViewModel = _mapper.Map<GetDriverViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion

#region Put Driver Handlers
public class PutDriverHandler :
    ResponseHandler,
    IRequestHandler<PutDriverCommand, Response<GetDriverViewModel>>
{
    public PutDriverHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(PutDriverCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.Id.Equals(null))
            return BadRequest<GetDriverViewModel>("id is required !");

        if (!await _context.Drivers.IsExist(d => d.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetDriverViewModel>($"driver with this id: {request.ViewModel.Id} not found");

        var model = _mapper.Map<Driver>(request.ViewModel);
        await _context.Drivers.UpdateAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }

        var resultViewModel = _mapper.Map<GetDriverViewModel>(model);
        return Accepted(resultViewModel, "update driver success !");
    }
}
#endregion

#region Delete Driver Handlers
public class DeleteDriverByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteDriverByIdCommand, Response<GetDriverViewModel>>
{
    public DeleteDriverByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(DeleteDriverByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetDriverViewModel>("id is required !");

        if (!await _context.Drivers.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetDriverViewModel>($"driver with this id: {request.Id} not found");

        await _context.Drivers.ExecuteDeleteAsync(d => d.Id.Equals(request.Id));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }

        return Delete<GetDriverViewModel>("delete driver success !");
    }
}

public class DeleteDriverBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeleteDriverBySSNCommand, Response<GetDriverViewModel>>
{
    public DeleteDriverBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(DeleteDriverBySSNCommand request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetDriverViewModel>("SSN is required!");

        if (!await _context.Drivers.IsExist(d => d.SSN.Equals(request.SSN)))
            return NotFound<GetDriverViewModel>($"driver with this SSN: {request.SSN} not found");

        await _context.Drivers.ExecuteDeleteAsync(d => d.SSN.Equals(request.SSN));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }
        return Delete<GetDriverViewModel>("delete driver success !");
    }
}

public class DeleteAllDriversHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllDriversCommand, Response<GetDriverViewModel>>
{
    public DeleteAllDriversHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetDriverViewModel>> Handle(DeleteAllDriversCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Drivers.IsExist())
            return NoContent<GetDriverViewModel>("no drivers founded !");
        try
        {
            await _context.Drivers.ExecuteDeleteAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetDriverViewModel>("Internal server error !");
        }
        return Delete<GetDriverViewModel>("delete driver success !");
    }
}
#endregion