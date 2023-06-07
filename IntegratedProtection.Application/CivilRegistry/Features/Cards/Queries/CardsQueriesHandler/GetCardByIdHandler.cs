using IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueriesHandler;

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
