namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommandsHandler;
public sealed class PostCriminalHandler :
    ResponseHandler,
    IRequestHandler<PostCriminalCommand, Response<GetCriminalViewModel>>
{
    public PostCriminalHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(PostCriminalCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Criminal>(request.ViewModel);

        var resultModel = await _context.Criminals.AddAsync(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCriminalViewModel>(resultModel);

        return Created(resultViewModel);
    }
}
