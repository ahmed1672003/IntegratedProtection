using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueriesHandler;

#region Get Person With Card Handler

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