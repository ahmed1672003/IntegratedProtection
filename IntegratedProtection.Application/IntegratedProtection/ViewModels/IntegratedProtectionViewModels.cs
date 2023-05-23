namespace IntegratedProtection.Application.IntegratedProtection.ViewModels;
public class GetPersonDataViewModel
{
    public GetPersonViewModel PersonData { get; set; }
    public GetCardViewModel CardData { get; set; }
}

public class GetCarDataViewModel
{
    public GetCarViewModel CarData { get; set; }
    public IEnumerable<GetDriverViewModel> DriverData { get; set; }
    public IEnumerable<GetTrafficOfficerViewModel> TrafficOfficerData { get; set; }
    public IEnumerable<GetStolenCarViewModel> StolenData { get; set; }
}

public class GetDriverDataViewModel
{
    public GetDriverViewModel DriverData { get; set; }
    public IEnumerable<GetCarViewModel> CarsData { get; set; }
}