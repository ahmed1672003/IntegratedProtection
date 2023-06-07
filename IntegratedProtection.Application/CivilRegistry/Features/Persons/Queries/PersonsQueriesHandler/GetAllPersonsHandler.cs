using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueriesHandler;
#region Get Person Handler

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