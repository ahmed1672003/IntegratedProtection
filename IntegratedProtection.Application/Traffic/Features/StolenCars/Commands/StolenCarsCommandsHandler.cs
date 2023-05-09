using IntegratedProtection.Infrastructure.Helpers;

namespace IntegratedProtection.Application.Traffic.Features.StolenCars.Commands;

#region Post

public class PostStolenCarHandler :
    ResponseHandler,
    IRequestHandler<PostStolenCarCommand, Response<GetStolenCarViewModel>>
{
    public PostStolenCarHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetStolenCarViewModel>>
        Handle(PostStolenCarCommand request, CancellationToken cancellationToken)
    {
        if (request.ViewModel.CarId.Equals(null) || request.ViewModel.TrafficOfficerId.Equals(null))
            return BadRequest<GetStolenCarViewModel>("carId & traffic officerId are required !");

        var model = _mapper.Map<StolenCar>(request.ViewModel);

        await _context.StolenCars.AddAsync(model);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest<GetStolenCarViewModel>("Internal server error !");
        }

        var stolenCarModel = await _context.StolenCars.GetAsync(
            s => s.CarId.Equals(request.ViewModel.CarId),
            new string[] { Include.Car, Include.TrafficOfficer });

        return Created(new GetStolenCarViewModel()
        {
            CarViewModel = _mapper.Map<GetCarViewModel>(stolenCarModel.Car),
            TrafficOfficerViewModel = _mapper.Map<GetTrafficOfficerViewModel>(stolenCarModel.TrafficOfficer)
        });
    }
}

#endregion
