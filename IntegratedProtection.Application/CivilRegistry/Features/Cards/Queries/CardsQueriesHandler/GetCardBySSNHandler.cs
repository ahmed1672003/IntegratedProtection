using IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueriesHandler;

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
