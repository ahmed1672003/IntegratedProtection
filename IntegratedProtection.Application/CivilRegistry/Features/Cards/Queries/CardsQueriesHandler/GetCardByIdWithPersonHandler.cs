using IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueriesHandler;

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
