using System.Net;

using AutoMapper;

using IntegratedProtection.Application.Bases;
using IntegratedProtection.Application.CentralSecurity.Features.Criminals.Queries.CriminalsQueriesHandler;
using IntegratedProtection.Application.CentralSecurity.ViewModels;
using IntegratedProtection.Application.Mapping;
using IntegratedProtection.Application.Test.Context.Test;
using IntegratedProtection.Infrastructure.Repositories;

using Shouldly;

namespace IntegratedProtection.Application.Test.CentralSecurity.Test.Features.Test.Criminals.Test.QueriesHandler.Test;
public class GetAllCriminalsHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _context;
    public GetAllCriminalsHandlerTest()
    {
        _context = new Mock<IUnitOfWork>();
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<IntegratedProtectionMapper>();
        });
        _mapper = mapperConfiguration.CreateMapper();
    }

    [Fact]
    public async Task Handle_CriminalNotFound_ReturnResponseWithStatusCodeIsOK()
    {
        // Arrange
        var dbContext = new InMemoryIntegratedProtectionDbContext(new());
        var r = _context.SetupGet(e => e.Criminals).Returns(new CriminalRepository(dbContext));
        var context = _context.Object;

        var handler = new GetAllCriminalsHandler(context, _mapper);

        // Actual 
        var actual = await handler.Handle(new(), CancellationToken.None);
        actual.ShouldBeOfType<Response<IEnumerable<GetCriminalViewModel>>>();


        var criminals = await context.Criminals.GetAllAsync();
        var criminalsViewModel = _mapper.Map<IEnumerable<GetCriminalViewModel>>(criminals);

        // expected
        var expected = new Response<IEnumerable<GetCriminalViewModel>>()
        {
            Data = criminalsViewModel,
            StatusCode = HttpStatusCode.NotFound,
        };

        // Assert 
        Assert.Equal(expected.StatusCode, actual.StatusCode);
    }


}
