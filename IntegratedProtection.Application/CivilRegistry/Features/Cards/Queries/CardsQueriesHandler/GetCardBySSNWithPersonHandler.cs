using IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries.CardsQueriesHandler;
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