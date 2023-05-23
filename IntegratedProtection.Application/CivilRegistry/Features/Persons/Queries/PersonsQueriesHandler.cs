namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;
#region Get Person Handler
public sealed class GetPersonByIdHandler :
    ResponseHandler,
    IRequestHandler<GetPersonByIdQuery, Response<GetPersonViewModel>>
{
    public GetPersonByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
            return BadRequest<GetPersonViewModel>("id is required !");

        if (!await _context.Persons.IsExist(e => e.Id == request.Id))
            return NotFound<GetPersonViewModel>("person not found !");

        var model = await _context.Persons.GetAsync(e => e.Id == request.Id);
        var viewModel = _mapper.Map<GetPersonViewModel>(model);
        return Success(viewModel);
    }
}

public sealed class GetPersonBySSNHandler :
    ResponseHandler,
    IRequestHandler<GetPersonBySSNQuery, Response<GetPersonViewModel>>
{
    public GetPersonBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>> Handle(GetPersonBySSNQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN == null)
            return BadRequest<GetPersonViewModel>("SSN is required !");

        if (!await _context.Persons.IsExist(e => e.SSN == request.SSN))
            return NotFound<GetPersonViewModel>("person not found");

        var model = await _context.Persons.GetAsync(e => e.SSN.Equals(request.SSN));

        var viewModel = _mapper.Map<GetPersonViewModel>(model);

        return Success(viewModel);
    }
}

public sealed class GetAllPersonsHandler :
    ResponseHandler,
    IRequestHandler<GetAllPersonsQuery, Response<IEnumerable<GetPersonViewModel>>>
{
    public GetAllPersonsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetPersonViewModel>>>
        Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
    {

        if (!await _context.Persons.IsExist())
            return NotFound<IEnumerable<GetPersonViewModel>>("no persons in system !");

        var models = await _context.Persons.GetAllAsync();

        var viewModels = _mapper.Map<IEnumerable<GetPersonViewModel>>(models);

        return Success(viewModels);
    }
}

#endregion

#region Get Person With Card Handler
public sealed class GetPersonsWithCardHandler :
    ResponseHandler,
    IRequestHandler<GetPersonByIdWithCardQuery, Response<GetPersonWithCardViewModel>>
{
    public GetPersonsWithCardHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonWithCardViewModel>>
        Handle(GetPersonByIdWithCardQuery request, CancellationToken cancellationToken)
    {
        if (request.PersonId == null)
            return BadRequest<GetPersonWithCardViewModel>($"id is required !");

        if (!await _context.Persons.IsExist(p => p.Id.Equals(request.PersonId)))
            return NotFound<GetPersonWithCardViewModel>
        ($"person with this id:{request.PersonId} not found");

        var model = await _context.Persons.
            GetAsync(p => p.Id.Equals(request.PersonId),
            new string[] { Include.Card });

        var personViewModel = _mapper.Map<GetPersonViewModel>(model);

        if (!await _context.Cards.IsExist(c => c.PersonId.Equals(request.PersonId)))
            return Success(new GetPersonWithCardViewModel()
            {
                GetPersonViewModel = personViewModel,
                GetCardViewModel = null
            }, message: "this person don't have a card !");


        var cardViewModel = _mapper.Map<GetCardViewModel>(model.Card);


        return Success(new GetPersonWithCardViewModel()
        {
            GetPersonViewModel = personViewModel,
            GetCardViewModel = cardViewModel
        }, message: "person with card retrieved successfully !");
    }
}

public sealed class GetPersonBySSNWithCardHandler :
    ResponseHandler,
    IRequestHandler<GetPersonBySSNWithCardQuery, Response<GetPersonWithCardViewModel>>
{
    public GetPersonBySSNWithCardHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonWithCardViewModel>>
        Handle(GetPersonBySSNWithCardQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetPersonWithCardViewModel>($"SSN is required !");

        if (!await _context.Persons.IsExist(p => p.SSN.Equals(request.SSN)))
            return NotFound<GetPersonWithCardViewModel>
        ($"person with this SSN:{request.SSN} not found");


        var model = await _context.Persons.
            GetAsync(p => p.SSN.Equals(request.SSN),
            new string[] { Include.Card });

        var personViewModel = _mapper.Map<GetPersonViewModel>(model);

        if (!await _context.Cards.IsExist(c => c.SSN.Equals(request.SSN)))
            return Success(new GetPersonWithCardViewModel()
            {
                GetPersonViewModel = personViewModel,
                GetCardViewModel = null
            }, message: "this person doesn't has a card !");


        var cardViewModel = _mapper.Map<GetCardViewModel>(model.Card);

        return Success(new GetPersonWithCardViewModel()
        {
            GetPersonViewModel = personViewModel,
            GetCardViewModel = cardViewModel
        }, message: "person with card retrieved successfully !");
    }
}
#endregion