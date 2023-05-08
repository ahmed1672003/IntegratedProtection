namespace IntegratedProtection.Application.Bases;

public class Handler
{
    protected readonly IUnitOfWork _context;
    protected readonly IMapper _mapper;

    public Handler(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
