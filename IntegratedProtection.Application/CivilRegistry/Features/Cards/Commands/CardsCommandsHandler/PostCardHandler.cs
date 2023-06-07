using IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommands;

namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Commands.CardsCommandsHandler;
#region Post Card Handler
public sealed class PostCardHandler :
    ResponseHandler,
    IRequestHandler<PostCardCommand, Response<GetCardViewModel>>
{
    private readonly IFileHelper _filesHelper;

    public PostCardHandler(IUnitOfWork context, IMapper mapper, IFileHelper filesHelper) : base(context, mapper)
    {
        _filesHelper = filesHelper;
    }

    public async Task<Response<GetCardViewModel>>
        Handle(PostCardCommand request, CancellationToken cancellationToken)
    {
        //var cardPhoto = await _filesHelper.ToByteArray(request.ViewModel.CardPhotoFile);

        //if (!_filesHelper.IsValidFile(cardPhoto, request.ViewModel.CardPhotoFile))
        //    return BadRequest<GetCardViewModel>
        //        ("allowed extension [ .jpg, .png, .jpeg ] and allowed max size is 5 MB !");

        var model = _mapper.Map<Card>(request.ViewModel);
        //model.CardPhoto = cardPhoto;


        var resultModel = await _context.Cards.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCardViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCardViewModel>(resultModel);

        return Created(resultViewModel);
    }
}

#endregion