using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueriesHandler;
#region Get Person Handler

public sealed class GetPersonBySSNHandler :
    ResponseHandler,
    IRequestHandler<GetPersonBySSNQuery, Response<GetPersonViewModel>>
{
    public GetPersonBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>> Handle(GetPersonBySSNQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN == null)
            return BadRequest<GetPersonViewModel>("SSN is required !");

        if (!await _context.Persons.IsExist(e => e.SSN == request.SSN))
            return NotFound<GetPersonViewModel>("person not found");

        var model = await _context.Persons.GetAsync(e => e.SSN.Equals(request.SSN));

        var viewModel = _mapper.Map<GetPersonViewModel>(model);

        return Success(viewModel);
    }
}
#endregion