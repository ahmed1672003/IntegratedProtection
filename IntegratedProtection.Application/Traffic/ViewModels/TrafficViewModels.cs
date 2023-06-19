namespace IntegratedProtection.Application.Traffic.ViewModels;


#region Cars View Models
public class PostCarViewModel
{
    [MaxLength(14)]
    public string OwnerSSN { get; set; }

    [MaxLength(100)]
    public string Model { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }

    [MaxLength(100)]
    public string Color { get; set; }

    [MaxLength(10)]
    public string Number { get; set; }

    [MaxLength(100)]
    public string Letters { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }
}

public class PutCarViewModel
{
    public int Id { get; set; }

    [MaxLength(14)]
    public string OwnerSSN { get; set; }

    [MaxLength(100)]
    public string Model { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }

    [MaxLength(100)]
    public string Color { get; set; }

    [MaxLength(10)]
    public string Number { get; set; }

    [MaxLength(100)]
    public string Letters { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

}


public class GetCarViewModel
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Model { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }

    [MaxLength(100)]
    public string Color { get; set; }

    public string CreatedDate { get; set; }

    public string EndDate { get; set; }

    public bool IsLicenseValid { get; set; }

    public string Plate { get; set; }

}

#endregion

#region Drivers View Models

public class PostDriverViewModel
{

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }
    //public bool IsLicenseFounded { get; set; }

}
public class PutDriverViewModel
{
    public int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }
    //public bool IsLicenseFounded { get; set; }

}

public class GetDriverViewModel
{
    public int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    public string CreatedDate { get; set; }

    public string EndDate { get; set; }

    public bool IsLicenseValid { get; set; }

    //public bool IsLicenseFounded { get; set; }
}
#endregion

#region TrafficOfficers View Models

public class PostTrafficOfficerViewModel
{
    public string Code { get; set; }

    [MaxLength(100)]
    public string Center { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string MiddelName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }
}

public class PutTrafficOfficerViewModel
{
    public int Id { get; set; }
    public string Code { get; set; }

    [MaxLength(100)]
    public string Center { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string MiddelName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }
}

public class GetTrafficOfficerViewModel
{
    public int Id { get; set; }
    public string Code { get; set; }

    [MaxLength(100)]
    public string Center { get; set; }

    public string FullName { get; set; }
}
#endregion

#region Stolen Cars View Models
public class PostStolenCarViewModel
{
    public int? CarId { get; set; }
    public int? TrafficOfficerId { get; set; }
    public DateTime CreatedDate { get; set; }
}


public class GetStolenCarViewModel
{
    public int? CarId { get; set; }
    public int? TrafficOfficerId { get; set; }
    public string CreatedDate { get; set; }
}

public class GetStolenCarWithTrafficOfficerViewModel
{
    public GetStolenCarViewModel GetStolenCarViewModel { get; set; }

    public GetTrafficOfficerViewModel GetTrafficOfficerViewModel { get; set; }
}
#endregion

#region Cars Drivers View Models
public class PostCarDriverViewModel
{
    public int? CarId { get; set; }

    public int? DriverId { get; set; }

    public DateTime CreatedData { get; set; }
}

public class GetCarDriverViewModel
{
    public int CarId { get; set; }

    public int DriverId { get; set; }

    public string CreatedData { get; set; }
}

#endregion


