namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;
#region Get Person Handler
public class GetPersonByIdHandler :
    ResponseHandler,
    IRequestHandler<GetPersonByIdQuery, Response<GetPersonViewModel>>
{
    public GetPersonByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var isModelExist = await _context.Persons.IsExist(e => e.Id == request.Id);
        if (!isModelExist)
        {
            return NotFound<GetPersonViewModel>("person not found !");
        }
        var model = await _context.Persons.GetAsync(e => e.Id == request.Id);
        var viewModel = _mapper.Map<GetPersonViewModel>(model);
        return Success(viewModel);
    }
}

public class GetPersonBySSNHandler :
    ResponseHandler,
    IRequestHandler<GetPersonBySSNQuery, Response<GetPersonViewModel>>
{
    public GetPersonBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>> Handle(GetPersonBySSNQuery request, CancellationToken cancellationToken)
    {
        var IsExist = await _context.Persons.IsExist(e => e.SSN == request.SSN);

        if (!IsExist)
            return NotFound<GetPersonViewModel>("person not found");

        var model = await _context.Persons.GetAsync(e => e.SSN.Equals(request.SSN));

        var viewModel = _mapper.Map<GetPersonViewModel>(model);

        return Success(viewModel);
    }
}
#endregion