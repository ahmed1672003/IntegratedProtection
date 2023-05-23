public record GetPersonDataQuery(string SSN) : IRequest<Response<GetPersonDataViewModel>>;

public record GetCarDataQuery(string Numbers, string Letters) : IRequest<Response<GetCarDataViewModel>>;

public record GetCriminalDataQuery(string SSN) : IRequest<Response<GetCriminalViewModel>>;

public record GetDriverDataQuery(string SSN) : IRequest<Response<GetDriverDataViewModel>>;

