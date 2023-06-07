using IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Persons.Commands.PersonsCommandsHandler;
#region Persons Handler
#region => Post Person Handler
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
        //var personalPhoto = await _fileHelper.ToByteArray(request.ViewModel.PersonPhotoFile);

        //if (!_fileHelper.IsValidFile(personalPhoto, request.ViewModel.PersonPhotoFile))
        //    return BadRequest<GetPersonViewModel>
        //        ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");

        if (!await _context.Persons.IsExist(e => e.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetPersonViewModel>("person not found !");

        var model = await _context.Persons.GetAsync(e => e.Id.Equals(request.ViewModel.Id));

        model = _mapper.Map<Person>(request.ViewModel);
        //model.PersonalPhoto = personalPhoto;
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
