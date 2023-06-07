using IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommandsHandler;
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
        //var personalPhoto = await _fileHelper.ToByteArray(request.ViewModel.PersonPhotoFile);

        //if (!_fileHelper.IsValidFile(personalPhoto, request.ViewModel.PersonPhotoFile))
        //    return BadRequest<GetPersonViewModel>
        //        ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");


        var model = _mapper.Map<Person>(request.ViewModel);
        //model.PersonalPhoto = personalPhoto;

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
#endregion
