using IntegratedProtection.Application.CivilRegistry.ViewModels;
using IntegratedProtection.Core.CivilRegistry;

namespace IntegratedProtection.Application.Mapping;

public class IntegratedProtectionMapper : Profile
{
    public IntegratedProtectionMapper()
    {
        PostPersonMapper();
        GetPersonMapper();

    }

    #region Persons Mapping
    public void PostPersonMapper()
    {
        CreateMap<PostPersonViewModel, Person>().ReverseMap();
    }
    public void GetPersonMapper()
    {
        CreateMap<GetPersonViewModel, Person>().ReverseMap();
    }
    #endregion

}
