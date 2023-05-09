namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;

public class GetAllCardsHandler :
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
public class GetCardByIdHandler :
    ResponseHandler,
    IRequestHandler<GetCardByIdQuery, Response<GetCardViewModel>>
{
    public GetCardByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCardViewModel>>
        Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
            return BadRequest<GetCardViewModel>("id is required !");

        if (!await _context.Cards.IsExist(e => e.Id.Equals(request.Id)))
            return NotFound<GetCardViewModel>("card with this is not found !");
        var resultModel = await _context.Cards.GetAsync(e => e.Id.Equals(request.Id));
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);
        return Success(resultViewModel);
    }
}
public class GetCardBySSNHandler :
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
