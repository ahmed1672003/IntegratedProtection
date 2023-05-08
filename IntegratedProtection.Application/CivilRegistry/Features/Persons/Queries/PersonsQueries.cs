namespace IntegratedProtection.Application.CivilRegistry.Features.Cards.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<Response<GetPersonViewModel>>;
public record GetPersonBySSNQuery(string SSN) : IRequest<Response<GetPersonViewModel>>;

