namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands;

#region Persons Handler

#region => Post Person Handler
public sealed class PostPersonHandler :
    ResponseHandler,
    IRequestHandler<PostPersonCommand, Response<GetPersonViewModel>>
{
    private readonly IFileHelper _fileHelper;
    public PostPersonHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(PostPersonCommand request, CancellationToken cancellationToken)
    {
        var personalPhoto = await _fileHelper.ToByteArray(request.ViewModel.PersonPhotoFile);

        if (!_fileHelper.IsValidFile(personalPhoto, request.ViewModel.PersonPhotoFile))
            return BadRequest<GetPersonViewModel>
                ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");


        var model = _mapper.Map<Person>(request.ViewModel);
        model.PersonalPhoto = personalPhoto;

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
public sealed class PutPersonHandler :
    ResponseHandler,
    IRequestHandler<PutPersonCommand, Response<GetPersonViewModel>>
{
    private readonly IFileHelper _fileHelper;

    public PutPersonHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _fileHelper = fileHelper;
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(PutPersonCommand request, CancellationToken cancellationToken)
    {
        var personalPhoto = await _fileHelper.ToByteArray(request.ViewModel.PersonPhotoFile);

        if (!_fileHelper.IsValidFile(personalPhoto, request.ViewModel.PersonPhotoFile))
            return BadRequest<GetPersonViewModel>
                ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");

        if (!await _context.Persons.IsExist(e => e.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetPersonViewModel>("person not found !");

        var model = await _context.Persons.GetAsync(e => e.Id.Equals(request.ViewModel.Id));

        model = _mapper.Map<Person>(request.ViewModel);
        model.PersonalPhoto = personalPhoto;
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

#region => Delete Person Handler
public sealed class DeletePersonByIdHandler :
    ResponseHandler,
    IRequestHandler<DeletePersonByIdCommand, Response<GetPersonViewModel>>
{
    public DeletePersonByIdHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Persons.IsExist(e => e.Id == request.Id))
            return NotFound<GetPersonViewModel>("person not found !");

        await _context.Persons.ExecuteDeleteAsync(e => e.Id == request.Id);

        return Delete<GetPersonViewModel>("person deleted success !");
    }
}

public sealed class DeletePersonBySSNHandler :
    ResponseHandler,
    IRequestHandler<DeletePersonBySSNCommand, Response<GetPersonViewModel>>
{
    public DeletePersonBySSNHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(DeletePersonBySSNCommand request, CancellationToken cancellationToken)
    {

        if (!await _context.Persons.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetPersonViewModel>("person not found !");

        await _context.Persons.ExecuteDeleteAsync(e => e.SSN.Equals(request.SSN));

        return Delete<GetPersonViewModel>("person deleted success !");
    }
}

public sealed class DeleteAllPersonsHandler :
    ResponseHandler,
    IRequestHandler<DeleteAllPersonsCommand, Response<GetPersonViewModel>>
{
    public DeleteAllPersonsHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonViewModel>>
        Handle(DeleteAllPersonsCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Persons.IsExist())
            return NotFound<GetPersonViewModel>("no persons founded !");

        await _context.Persons.ExecuteDeleteAsync();

        return Delete<GetPersonViewModel>("Deleted all persons success !");
    }
}

#endregion
#endregion
