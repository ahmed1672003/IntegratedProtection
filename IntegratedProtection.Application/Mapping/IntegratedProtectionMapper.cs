namespace IntegratedProtection.Application.Mapping;

public class IntegratedProtectionMapper : Profile
{
    public IntegratedProtectionMapper()
    {
        PostPersonMapper();
        GetPersonMapper();
        PutPersonMapper();
    }

    #region Persons Mapping
    public void PostPersonMapper()
    {
        CreateMap<PostPersonViewModel, Person>().ReverseMap();

    }

    public void PutPersonMapper()
    {
        CreateMap<PutPersonViewModel, Person>().ReverseMap();
    }

    public void GetPersonMapper()
    {
        CreateMap<Person, GetPersonViewModel>()
            .ForMember(dist => dist.DateOfBirth,
          cfg =>
          cfg.MapFrom(src => src.DateOfBirth.ToString("MMMM dd, yyyy")));
    }

    #endregion

}
