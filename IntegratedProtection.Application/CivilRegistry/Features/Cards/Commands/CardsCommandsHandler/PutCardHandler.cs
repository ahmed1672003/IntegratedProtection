using IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommandsHandler;
#region Put Card Handler
public sealed class PutCardHandler :
    ResponseHandler,
    IRequestHandler<PutCardCommand, Response<GetCardViewModel>>
{
    private readonly IFileHelper _filesHelper;
    public PutCardHandler(IUnitOfWork context, IMapper mapper, IFileHelper fileHelper) : base(context, mapper)
    {
        _filesHelper = fileHelper;
    }

    public async Task<Response<GetCardViewModel>>
        Handle(PutCardCommand request, CancellationToken cancellationToken)
    {
        //var cardPhoto = await _filesHelper.ToByteArray(request.ViewModel.CardPhotoFile);

        //if (!_filesHelper.IsValidFile(cardPhoto, request.ViewModel.CardPhotoFile))
        //    return BadRequest<GetCardViewModel>
        //        ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");

        if (!await _context.Cards.IsExist(c => c.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCardViewModel>("card with this id not found !");

        if (!await _context.Persons.IsExist(p => p.Id.Equals(request.ViewModel.PersonId)))
            return NotFound<GetCardViewModel>($"person with this id {request.ViewModel.PersonId} not found");

        var model = _mapper.Map<Card>(request.ViewModel);
        //model.CardPhoto = cardPhoto;

        var resultModel = await _context.Cards.UpdateAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);

        return Accepted(resultViewModel, "Update card success !");

    }
}

#endregion