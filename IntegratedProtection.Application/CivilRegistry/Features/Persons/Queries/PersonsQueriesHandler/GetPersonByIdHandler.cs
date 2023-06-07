using IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueries;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Queries.PersonsQueriesHandler;
#region Get Person Handler
public sealed class GetPersonByIdHandler :
    ResponseHandler,
    IRequestHandler<GetPersonByIdQuery, Response<GetPersonViewModel>>
{
    public GetPersonByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
            return BadRequest<GetPersonViewModel>("id is required !");

        if (!await _context.Persons.IsExist(e => e.Id == request.Id))
            return NotFound<GetPersonViewModel>("person not found !");

        var model = await _context.Persons.GetAsync(e => e.Id == request.Id);
        var viewModel = _mapper.Map<GetPersonViewModel>(model);
        return Success(viewModel);
    }
}
#endregion