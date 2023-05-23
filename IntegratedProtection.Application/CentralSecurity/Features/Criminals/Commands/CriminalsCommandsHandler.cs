

namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands;

#region Post
public sealed class PostCriminalHandler :
    ResponseHandler,
    IRequestHandler<PostCriminalCommand, Response<GetCriminalViewModel>>
{
    public PostCriminalHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(PostCriminalCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Criminal>(request.ViewModel);

        var resultModel = await _context.Criminals.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCriminalViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
#endregion

#region Put 
public sealed class PutCriminalHandler :
    ResponseHandler,
    IRequestHandler<PutCriminalCommand, Response<GetCriminalViewModel>>
{
    public PutCriminalHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(PutCriminalCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Criminals.IsExist(e => e.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCriminalViewModel>($"criminal with this id: {request.ViewModel.Id} not found !");


        var model = _mapper.Map<Criminal>(request.ViewModel);

        var resultModel = await _context.Criminals.UpdateAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCriminalViewModel>(resultModel);

        return Success(resultViewModel, message: "updated successfully !");
    }
}
#endregion

#region Delete 
public sealed class DeleteCriminalByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteCriminalByIdCommand, Response<GetCriminalViewModel>>
{
    public DeleteCriminalByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(DeleteCriminalByIdCommand request, CancellationToken cancellationToken)
    {

        if (request.Id.Equals(null))
            return BadRequest<GetCriminalViewModel>("Id is required !");

        if (!await _context.Criminals.IsExist(e => e.Id.Equals(request.Id)))
            return NotFound<GetCriminalViewModel>($"this criminal with this Id:{request.Id} not found !");
        await _context.Criminals.ExecuteDeleteAsync(e => e.Id.Equals(request.Id));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }
        return Delete<GetCriminalViewModel>("deleted success !");
    }
}

public sealed class DeleteCriminalBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeleteCriminalBySSNCommand, Response<GetCriminalViewModel>>
{
    public DeleteCriminalBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(DeleteCriminalBySSNCommand request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetCriminalViewModel>("SSN is required !");

        if (!await _context.Criminals.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetCriminalViewModel>($"criminal with this SSN: {request.SSN} not found !");

        await _context.Criminals.ExecuteDeleteAsync(e => e.SSN.Equals(request.SSN));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }


        return Delete<GetCriminalViewModel>("deleted success !");
    }
}

public sealed class DeleteAllCriminalsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCriminalsCommand, Response<GetCriminalViewModel>>
{
    public DeleteAllCriminalsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(DeleteAllCriminalsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Criminals.IsExist())
            return NotFound<GetCriminalViewModel>("criminals not founded !");

        await _context.Criminals.ExecuteDeleteAsync();

        return Delete<GetCriminalViewModel>("deleted success !");
    }
}
#endregion