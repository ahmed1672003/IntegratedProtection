using IntegratedProtection.Application.IHelpers;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;
#region Post Card Handler
public class PostCardHandler :
    ResponseHandler,
    IRequestHandler<PostCardCommand, Response<GetCardViewModel>>
{
    private readonly IFileHelper<Card> _filesHelper;

    public PostCardHandler(IUnitOfWork context, IMapper mapper, IFileHelper<Card> filesHelper) : base(context, mapper)
    {
        _filesHelper = filesHelper;
    }

    public async Task<Response<GetCardViewModel>>
        Handle(PostCardCommand request, CancellationToken cancellationToken)
    {

        //var imageWithStatus = await request.ViewModel.CardFile.ToByteArray();

        //if (!imageWithStatus.Value)
        //    return BadRequest<GetCardViewModel>("{.jpg,.png .jpeg } & {Max size is 1 MB} only are allowed !");

        var model = _mapper.Map<Card>(request.ViewModel);
        //model.CardPhoto = imageWithStatus.Key;

        model.CardPhotoPath = await _filesHelper.ToStore(request.ViewModel.CardFile);

        var resultModel = await _context.Cards.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);

        return Created(resultViewModel);
    }
}

#endregion

#region Put Card Handler
public class PutCardHandler :
    ResponseHandler,
    IRequestHandler<PutCardCommand, Response<GetCardViewModel>>
{
    public PutCardHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(PutCardCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cards.IsExist(c => c.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCardViewModel>("card with this id not found !");

        if (!await _context.Persons.IsExist(p => p.Id.Equals(request.ViewModel.PersonId)))
            return NotFound<GetCardViewModel>($"person with this id {request.ViewModel.PersonId} not found");

        //var imageWithStatus = await request.ViewModel.CardFile.ToByteArray();

        //if (!imageWithStatus.Value)
        //    return BadRequest<GetCardViewModel>("{ .jpg ,.png , .jpeg } & { Max size is 4 MB } only are allowed !");

        var model = _mapper.Map<Card>(request.ViewModel);
        //model.CardPhoto = imageWithStatus.Key;
        //model.CardPhotoPath = 

        var resultModel = await _context.Cards.UpdateAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);

        return Accepted(resultViewModel, "Update card success !");

    }
}

#endregion

#region Delete Card Handler
public class DeleteCardByIdHandler :
    ResponseHandler,
    IRequestHandler<DeleteCardByIdCommand, Response<GetCardViewModel>>
{
    public DeleteCardByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {

    }

    public async Task<Response<GetCardViewModel>>
        Handle(DeleteCardByIdCommand request, CancellationToken cancellationToken)
    {

        if (request.Id.Equals(null))
            return BadRequest<GetCardViewModel>("id is required !");


        if (!await _context.Cards.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetCardViewModel>($"card with this id:{request.Id} not found !");

        await _context.Cards.ExecuteDeleteAsync(c => c.Id.Equals(request.Id));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }

        return Delete<GetCardViewModel>("deleted card success !");
    }
}

public class DeleteCardBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeleteCardBySSNCommand, Response<GetCardViewModel>>
{
    public DeleteCardBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(DeleteCardBySSNCommand request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetCardViewModel>("SSN is required !");

        if (!await _context.Cards.IsExist(c => c.SSN.Equals(request.SSN)))
            return NotFound<GetCardViewModel>($"card with this SSN:{request.SSN} not found !");

        await _context.Cards.ExecuteDeleteAsync(c => c.Id.Equals(request.SSN));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }
        return Delete<GetCardViewModel>("deleted card success !");

    }
}

public class DeleteAllCardsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllCardsCommand, Response<GetCardViewModel>>
{
    public DeleteAllCardsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(DeleteAllCardsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Cards.IsExist())
            return NotFound<GetCardViewModel>("no cards found !");

        await _context.Cards.ExecuteDeleteAsync();

        return Delete<GetCardViewModel>("deleted all cards success !");
    }
}

#endregion