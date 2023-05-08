namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;

#region Persons Handler

#region => Post Person Handler
public class PostPersonHandler :
    ResponseHandler,
    IRequestHandler<PostPersonCommand, Response<GetPersonViewModel>>
{
    public PostPersonHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetPersonViewModel>>
        Handle(PostPersonCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Person>(request.ViewModel);
        await _context.Persons.AddAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetPersonViewModel>("internal server error");
        }

        var resultModel = await _context.Persons.GetAsync(e => e.SSN == model.SSN);
        var resultViewModel = _mapper.Map<GetPersonViewModel>(resultModel);
        return Created(resultViewModel);
    }
}
#endregion

#region => Put Person Handler
public class PutPersonHandler :
    ResponseHandler,
    IRequestHandler<PutPersonCommand, Response<GetPersonViewModel>>
{
    public PutPersonHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetPersonViewModel>>
        Handle(PutPersonCommand request, CancellationToken cancellationToken)
    {
        var viewModel = request.ViewModel;
        var model = _mapper.Map<Person>(viewModel);
        var resultModel = await _context.Persons.UpdateAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            return BadRequest<GetPersonViewModel>("internal server error");
        }
        var resultViewModel = _mapper.Map<GetPersonViewModel>(resultModel);
        return Accepted(resultViewModel, message: "Update Success ");
    }
}

#endregion


#endregion
