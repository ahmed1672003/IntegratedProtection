


namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;

public sealed class GetAllCardsHandler :
    ResponseHandler,
    IRequestHandler<GetAllCardsQuery, Response<IEnumerable<GetCardViewModel>>>
{
    public GetAllCardsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetCardViewModel>>>
        Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Cards.IsExist())
            return NotFound<IEnumerable<GetCardViewModel>>("no cards founded !");

        var models = await _context.Cards.GetAllAsync();
        var viewModels = _mapper.Map<IEnumerable<GetCardViewModel>>(models);
        return Success(viewModels);
    }
}
public sealed class GetCardByIdHandler :
    ResponseHandler,
    IRequestHandler<GetCardByIdQuery, Response<GetCardViewModel>>
{
    public GetCardByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetCardViewModel>("id is required !");

        if (!await _context.Cards.IsExist(e => e.Id.Equals(request.Id)))
            return NotFound<GetCardViewModel>("card with this is not found !");
        var resultModel = await _context.Cards.GetAsync(e => e.Id.Equals(request.Id));
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);
        return Success(resultViewModel);
    }
}
public sealed class GetCardBySSNHandler :
    ResponseHandler,
    IRequestHandler<GetCardBySSNQuery, Response<GetCardViewModel>>
{
    public GetCardBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>> Handle(GetCardBySSNQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN == null)
            return BadRequest<GetCardViewModel>("SSN is required !");

        if (!await _context.Cards.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetCardViewModel>("card with this SSN not found !");

        var resultModel = await _context.Cards.GetAsync(c => c.SSN.Equals(request.SSN));
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);
        return Success(resultViewModel);
    }
}
public sealed class GetCardByIdWithPersonHandler :
    ResponseHandler,
    IRequestHandler<GetCardByIdWithPersonQuery, Response<GetPersonWithCardViewModel>>
{
    public GetCardByIdWithPersonHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonWithCardViewModel>>
        Handle(GetCardByIdWithPersonQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.Equals(null))
            return BadRequest<GetPersonWithCardViewModel>("id is required !");

        if (!await _context.Cards.IsExist(c => c.Id.Equals(request.Id)))
            return NotFound<GetPersonWithCardViewModel>($"card with this id:{request.Id} not founded !");

        var model = await _context.Cards.GetAsync(
            c => c.Id.Equals(request.Id),
            new string[] { Include.Person });
        var cardViewModel = _mapper.Map<GetCardViewModel>(model);


        if (model.Person.Equals(null))
            return Success(new GetPersonWithCardViewModel()
            {
                GetCardViewModel = cardViewModel,
                GetPersonViewModel = null
            }, message: "no person founded with this card !");

        var personViewModel = _mapper.Map<GetPersonViewModel>(model.Person);

        return Success(new GetPersonWithCardViewModel()
        {
            GetPersonViewModel = personViewModel,
            GetCardViewModel = cardViewModel
        }, message: "person with card retrieved successfully !");
    }
}
public sealed class GetCardBySSNWithPersonHandler :
    ResponseHandler,
    IRequestHandler<GetCardBySSNWithPersonQuery, Response<GetPersonWithCardViewModel>>

{
    public GetCardBySSNWithPersonHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonWithCardViewModel>>
        Handle(GetCardBySSNWithPersonQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetPersonWithCardViewModel>("id is required !");

        if (!await _context.Cards.IsExist(c => c.SSN.Equals(request.SSN)))
            return NotFound<GetPersonWithCardViewModel>($"card with this SSN:{request.SSN} not founded !");

        var model = await _context.Cards.GetAsync(
            c => c.SSN.Equals(request.SSN),
            new string[] { Include.Person });
        var cardViewModel = _mapper.Map<GetCardViewModel>(model);


        if (model.Person.Equals(null))
            return Success(new GetPersonWithCardViewModel()
            {
                GetCardViewModel = cardViewModel,
                GetPersonViewModel = null
            }, message: "no person founded with this card !");

        var personViewModel = _mapper.Map<GetPersonViewModel>(model.Person);

        return Success(new GetPersonWithCardViewModel()
        {
            GetPersonViewModel = personViewModel,
            GetCardViewModel = cardViewModel
        }, message: "person with card retrieved successfully !");
    }
}