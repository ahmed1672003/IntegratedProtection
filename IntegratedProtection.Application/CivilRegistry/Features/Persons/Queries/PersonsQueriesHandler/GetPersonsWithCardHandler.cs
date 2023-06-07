using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueriesHandler;
#region Get Person Handler

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
#endregion