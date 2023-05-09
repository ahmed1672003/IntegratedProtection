

namespace IntegratedProtection.Application.Mapping;

public class IntegratedProtectionMapper : Profile
{
    public IntegratedProtectionMapper()
    {
        #region CivilRegistry Mapper

        #region Persons Mapping
        PostPersonMapper();
        GetPersonMapper();
        PutPersonMapper();
        #endregion

        #region Cards Mapper
        PostCardMapper();
        PutCardMapper();
        GetCardMapper();
        #endregion

        #endregion


        #region Traffic Mapper

        #region Cars Mapping
        PostCarMapper();
        PutCarMapper();
        GetCarMapper();
        #endregion

        #region CarsDrivers Mapping

        #endregion

        #region StolenCars Mapping

        #endregion

        #region TrafficOfficers Mapping

        #endregion

        #endregion
    }

    #region CivilRegistry Mapper
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

    #region Cards Mapper
    public void PostCardMapper()
    {
        CreateMap<Card, PostCardViewModel>().ReverseMap();
    }
    public void PutCardMapper()
    {
        CreateMap<Card, PutCardViewModel>().ReverseMap();
    }
    public void GetCardMapper()
    {
        CreateMap<Card, GetCardViewModel>()
            .ForMember(dist => dist.CreatedDate,
            cfg =>
            cfg.MapFrom(src => src.CreatedDate.ToString("MMM dd,yyyy")))

            .ForMember(dist => dist.EndDate,
            cfg =>
            cfg.MapFrom(src => src.EndDate.ToString("MMM dd,yyyy"))).ReverseMap();
    }
    #endregion
    #endregion

    #region Traffic Mapper

    #region Cars Mapping
    public void PostCarMapper()
    {
        CreateMap<PostCarViewModel, Car>().ReverseMap();
    }
    public void PutCarMapper()
    {
        CreateMap<PutCarViewModel, Car>().ReverseMap();
    }
    public void GetCarMapper()
    {
        CreateMap<Car, GetCarViewModel>()
        .ForMember(dist => dist.CreatedDate,
        cfg =>
        cfg.MapFrom(src => src.CreatedDate.ToString("MMMM dd, yyyy")))
        .ForMember(dist => dist.EndDate,
        cfg =>
        cfg.MapFrom(src => src.EndDate.ToString("MMMM dd, yyyy")));
    }
    #endregion

    #region CarsDrivers Mapping

    #endregion

    #region StolenCars Mapping

    #endregion

    #region TrafficOfficers Mapping

    #endregion

    #endregion
}
