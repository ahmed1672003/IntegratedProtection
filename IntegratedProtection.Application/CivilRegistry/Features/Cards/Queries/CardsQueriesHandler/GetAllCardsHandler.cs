using IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueriesHandler;

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
