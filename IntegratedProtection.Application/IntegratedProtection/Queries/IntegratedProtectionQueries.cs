public record GetPersonDataQuery(string SSN) : IRequest<Response<GetPersonDataViewModel>>;

public record GetCarDataQuery(string Numbers, string Letters) : IRequest<Response<GetCarDataViewModel>>;