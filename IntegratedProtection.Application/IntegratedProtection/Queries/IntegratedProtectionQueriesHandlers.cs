public sealed class GetPersonDataHandler :
    ResponseHandler,
    IRequestHandler<GetPersonDataQuery, Response<GetPersonDataViewModel>>
{
    public GetPersonDataHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Response<GetPersonDataViewModel>>
        Handle(GetPersonDataQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetPersonDataViewModel>("SSN is required !");

        if (!await _context.Persons.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetPersonDataViewModel>($"no person founded by this SSN: {request.SSN}");

        var person = await _context.Persons.GetAsync(e => e.SSN.Equals(request.SSN));

        var result = await _context.Persons.GetRelatedDataAsync(person.Id);

        if (result.Card != null)
            return Success<GetPersonDataViewModel>(data: new()
            {
                PersonData = _mapper.Map<GetPersonViewModel>(result),
                CardData = _mapper.Map<GetCardViewModel>(result.Card)
            });

        return Success<GetPersonDataViewModel>(data: new()
        {
            PersonData = _mapper.Map<GetPersonViewModel>(result),
            CardData = null
        }, message: "no card for this person !");
    }
}

public sealed class GetCarDataHandler
    : ResponseHandler,
    IRequestHandler<GetCarDataQuery, Response<GetCarDataViewModel>>
{
    public GetCarDataHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetCarDataViewModel>>
        Handle(GetCarDataQuery request, CancellationToken cancellationToken)
    {
        if (request.Numbers.Equals(null) || request.Letters.Equals(null))
            return BadRequest<GetCarDataViewModel>("numbers and letters are required !");

        if (!await _context.Cars.IsExist(e => e.Letters.Equals(request.Letters) && e.Number.Equals(request.Numbers)))
            return NotFound<GetCarDataViewModel>($"no car founded with Number: {request.Numbers} & Letters: {request.Letters}");

        var car = await _context
            .Cars.
            GetAsync(e => e.Letters.Equals(request.Letters) && e.Number.Equals(request.Numbers));

        var result = await _context.Cars.GetRelatedDataAsync(car.Id);

        if (result.CarDriver != null && result.StolenCars != null)
            return Success<GetCarDataViewModel>(data: new()
            {
                CarData = _mapper.Map<GetCarViewModel>(result),
                StolenData = _mapper.Map<IEnumerable<GetStolenCarViewModel>>(result.StolenCars),
                DriverData = _mapper.Map<IEnumerable<GetDriverViewModel>>(result.CarDriver.Select(e => e.Driver)),
                TrafficOfficerData = _mapper.Map<IEnumerable<GetTrafficOfficerViewModel>>
                (result.StolenCars.Select(e => e.TrafficOfficer))
            });

        if (result.CarDriver != null && result.StolenCars == null)
            return Success<GetCarDataViewModel>(data: new()
            {
                CarData = _mapper.Map<GetCarViewModel>(result),
                DriverData = _mapper.Map<IEnumerable<GetDriverViewModel>>(result.CarDriver.Select(e => e.Driver)),
            });

        if (result.StolenCars != null && result.CarDriver == null)
            return Success<GetCarDataViewModel>(data: new()
            {
                CarData = _mapper.Map<GetCarViewModel>(result),
                StolenData = _mapper.Map<IEnumerable<GetStolenCarViewModel>>(result.StolenCars),
                TrafficOfficerData = _mapper.Map<IEnumerable<GetTrafficOfficerViewModel>>
                (result.StolenCars.Select(e => e.TrafficOfficer)),
                DriverData = null,
            });

        return Success<GetCarDataViewModel>(data: new()
        {
            CarData = _mapper.Map<GetCarViewModel>(result),
            DriverData = null,
            StolenData = null,
            TrafficOfficerData = null,
        });
    }
}

public sealed class GetCriminalHandler
    : ResponseHandler,
    IRequestHandler<GetCriminalDataQuery, Response<GetCriminalViewModel>>
{
    public GetCriminalHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetCriminalViewModel>>
        Handle(GetCriminalDataQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetCriminalViewModel>("SSN is required !");

        if (!await _context.Criminals.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetCriminalViewModel>("person with this SSN not found in Criminals !");

        var criminal = await _context.Criminals.GetAsync(e => e.SSN.Equals(request.SSN));

        var criminalViewModel = _mapper.Map<GetCriminalViewModel>(criminal);

        return Success(criminalViewModel, message: "criminal person founded");
    }
}

public sealed class GetDriverDataHandler
    : ResponseHandler,
    IRequestHandler<GetDriverDataQuery, Response<GetDriverDataViewModel>>
{
    public GetDriverDataHandler(IUnitOfWork context, IMapper mapper) : base(context, mapper) { }

    public async Task<Response<GetDriverDataViewModel>>
        Handle(GetDriverDataQuery request, CancellationToken cancellationToken)
    {
        if (request.SSN.Equals(null))
            return BadRequest<GetDriverDataViewModel>("SSN is required !");

        if (!await _context.Drivers.IsExist(e => e.SSN.Equals(request.SSN)))
            return NotFound<GetDriverDataViewModel>($"no driver founded with this SSN: {request.SSN}");

        var driver = await _context.Drivers.GetAsync(e => e.SSN.Equals(request.SSN));

        var result = await _context.Drivers.GetRelatedDataAsync(driver.Id);

        if (result.CarsDrivers.Any())
            return Success<GetDriverDataViewModel>(data: new()
            {
                DriverData = _mapper.Map<GetDriverViewModel>(result),
                CarsData = _mapper.Map<IEnumerable<GetCarViewModel>>(result.CarsDrivers.Select(e => e.Car)),
            });
        return Success<GetDriverDataViewModel>(data: new()
        {
            DriverData = _mapper.Map<GetDriverViewModel>(result),
            CarsData = null
        });
    }
}