using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueriesHandler;
public class GetAllPersonsWithCompileHandler :
    ResponseHandler,
    IRequestHandler<GetAllPersonsWithCompileQuery, Response<IEnumerable<GetPersonViewModel>>>
{
    public GetAllPersonsWithCompileHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<IEnumerable<GetPersonViewModel>>>
        Handle(GetAllPersonsWithCompileQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Persons.IsExist())
            return NotFound<IEnumerable<GetPersonViewModel>>("no persons in system !");
        var models = await _context.Persons.GetAllAsyncOptimizedQuery();

        var viewModels = _mapper.Map<IEnumerable<GetPersonViewModel>>(models);

        return Success(viewModels);
    }
}
