namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;

#region Post Card Handler
public sealed class PostCardHandler :
    ResponseHandler,
    IRequestHandler<PostCardCommand, Response<GetCardViewModel>>
{
    private readonly IFileHelper _filesHelper;

    public PostCardHandler(IUnitOfWork context, IMapper mapper, IFileHelper filesHelper) : base(context, mapper)
    {
        _filesHelper = filesHelper;
    }

    public async Task<Response<GetCardViewModel>>
        Handle(PostCardCommand request, CancellationToken cancellationToken)
    {
        var cardPhoto = await _filesHelper.ToByteArray(request.ViewModel.CardPhotoFile);

        if (!_filesHelper.IsValidFile(cardPhoto, request.ViewModel.CardPhotoFile))
            return BadRequest<GetCardViewModel>
                ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");

        var model = _mapper.Map<Card>(request.ViewModel);
        model.CardPhoto = cardPhoto;


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
public sealed class PutCardHandler :
    ResponseHandler,
    IRequestHandler<PutCardCommand, Response<GetCardViewModel>>
{
    private readonly IFileHelper _filesHelper;
    public PutCardHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _filesHelper = fileHelper;
    }

    public async Task<Response<GetCardViewModel>>
        Handle(PutCardCommand request, CancellationToken cancellationToken)
    {
        var cardPhoto = await _filesHelper.ToByteArray(request.ViewModel.CardPhotoFile);

        if (!_filesHelper.IsValidFile(cardPhoto, request.ViewModel.CardPhotoFile))
            return BadRequest<GetCardViewModel>
                ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");

        if (!await _context.Cards.IsExist(c => c.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCardViewModel>("card with this id not found !");

        if (!await _context.Persons.IsExist(p => p.Id.Equals(request.ViewModel.PersonId)))
            return NotFound<GetCardViewModel>($"person with this id {request.ViewModel.PersonId} not found");

        var model = _mapper.Map<Card>(request.ViewModel);
        model.CardPhoto = cardPhoto;

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
public sealed class DeleteCardByIdHandler :
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

public sealed class DeleteCardBySSNHandler :
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

public sealed class DeleteAllCardsHandler :
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