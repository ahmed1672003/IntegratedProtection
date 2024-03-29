﻿using IntegratedProtection.Application.Folders.ViewModels;
using IntegratedProtection.Core.FilesEntity;

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

        #region Central Security Mapper

        #region Criminals Mapping
        PostCriminalMapper();
        PutCriminalMapper();
        GetCriminalMapper();
        #endregion

        #endregion

        #region Traffic Mapper

        #region Cars Mapping
        PostCarMapper();
        PutCarMapper();
        GetCarMapper();
        #endregion

        #region Driver Mapping
        PostDriverMapper();
        PutDriverMapper();
        GetDriverMapper();
        #endregion

        #region TrafficOfficers Mapping
        PostTrafficOfficerMapper();
        PutTrafficOfficerMapper();
        GetTrafficOfficerMapper();
        #endregion

        #region StolenCars Mapping
        PostStolenCarMapper();
        GetStolenCarMapper();
        #endregion

        #region CarsDrivers Mapping
        PostCarDriverMapper();
        GetCarDriverMapper();
        #endregion

        #endregion

        #region Files Mapper
        PostFileMapper();
        GetFileMapper();
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
        cfg.MapFrom(src => src.DateOfBirth.ToShortDateString()))

        //.ForMember(dist => dist.PersonPhotoBase64,
        //cfg =>
        //cfg.MapFrom(src => Convert.ToBase64String(src.PersonalPhoto)))
        .ReverseMap();
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
            cfg.MapFrom(src => src.CreatedDate.ToShortDateString()))

            .ForMember(dist => dist.EndDate,
            cfg =>
            cfg.MapFrom(src => src.EndDate.ToShortDateString()))

            //.ForMember(dist => dist.CardPhotoBase64,
            //cfg =>
            //cfg.MapFrom(src => Convert.ToBase64String(src.CardPhoto)))
            .ReverseMap();
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
        cfg.MapFrom(src => src.CreatedDate.ToShortDateString()))
        .ForMember(dist => dist.EndDate,
        cfg =>
        cfg.MapFrom(src => src.EndDate.ToShortDateString()));
    }
    #endregion

    #region Drivers Mapping
    public void PostDriverMapper()
    {
        CreateMap<PostDriverViewModel, Driver>().ReverseMap();
    }

    public void PutDriverMapper()
    {
        CreateMap<PutDriverViewModel, Driver>().ReverseMap();
    }
    public void GetDriverMapper()
    {
        CreateMap<Driver, GetDriverViewModel>()
        .ForMember(dist => dist.CreatedDate,
            cfg =>
            cfg.MapFrom(src => src.CreatedDate.ToShortDateString()))
        .ForMember(dist => dist.EndDate,
        cfg =>
        cfg.MapFrom(src => src.EndDate.ToShortDateString()))
        .ReverseMap();

    }
    #endregion

    #region TrafficOfficers Mapping
    public void PostTrafficOfficerMapper()
    {
        CreateMap<PostTrafficOfficerViewModel, TrafficOfficer>().ReverseMap();
    }

    public void PutTrafficOfficerMapper()
    {
        CreateMap<PutTrafficOfficerViewModel, TrafficOfficer>().ReverseMap();
    }

    public void GetTrafficOfficerMapper()
    {
        CreateMap<TrafficOfficer, GetTrafficOfficerViewModel>().ReverseMap();
    }
    #endregion

    #region StolenCars Mapping
    public void PostStolenCarMapper()
    {
        CreateMap<PostStolenCarViewModel, StolenCar>().ReverseMap();
    }
    public void GetStolenCarMapper()
    {
        CreateMap<StolenCar, GetStolenCarViewModel>()
            .ForMember(dist => dist.CreatedDate,
            cfg =>
            cfg.MapFrom(src => src.CreatedDate.ToShortDateString()));
    }

    #endregion

    #region Cars Drivers
    public void PostCarDriverMapper()
    {
        CreateMap<PostCarDriverViewModel, CarDriver>().ReverseMap();
    }

    public void GetCarDriverMapper()
    {
        CreateMap<CarDriver, GetCarDriverViewModel>()
            .ForMember(dist => dist.CreatedData,
            cfg =>
            cfg.MapFrom(src => src.CreatedData.ToShortDateString()));
    }
    #endregion

    #endregion

    #region Central Security Mapper

    #region Criminals Mapping
    public void PostCriminalMapper()
    {
        CreateMap<PostCriminalViewModel, Criminal>().ReverseMap();
    }
    public void PutCriminalMapper()
    {
        CreateMap<PutCriminalViewModel, Criminal>().ReverseMap();
    }
    public void GetCriminalMapper()
    {
        CreateMap<Criminal, GetCriminalViewModel>()
            .ForMember(dist => dist.CreatedData,
            cfg =>
            cfg.MapFrom(src => src.CreatedData.ToShortDateString()));
    }

    #endregion

    #endregion


    #region Files
    // ToDo Mapping
    public void PostFileMapper()
    {
        CreateMap<PostFileViewModel, CarFile>().ReverseMap();
        CreateMap<PostFileViewModel, PersonFile>().ReverseMap();
    }

    public void GetFileMapper()
    {
        CreateMap<CarFile, GetFileViewModel>().ReverseMap();
        CreateMap<PersonFile, GetFileViewModel>().ReverseMap();
    }
    #endregion
}
