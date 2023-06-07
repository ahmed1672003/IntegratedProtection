namespace IntegratedProtection.Application.CentralSecurity.Features.Criminals.Commands.CriminalsCommandsHandler;


public sealed class PutCriminalHandler :
    ResponseHandler,
    IRequestHandler<PutCriminalCommand, Response<GetCriminalViewModel>>
{
    public PutCriminalHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetCriminalViewModel>>
        Handle(PutCriminalCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Criminals.IsExist(e => e.Id.Equals(request.ViewModel.Id)))
            return NotFound<GetCriminalViewModel>($"criminal with this id: {request.ViewModel.Id} not found !");


        var model = _mapper.Map<Criminal>(request.ViewModel);

        var resultModel = await _context.Criminals.UpdateAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetCriminalViewModel>("Internal server error !");
        }
        var resultViewModel = _mapper.Map<GetCriminalViewModel>(resultModel);

        return Success(resultViewModel, message: "updated successfully !");
    }
}
