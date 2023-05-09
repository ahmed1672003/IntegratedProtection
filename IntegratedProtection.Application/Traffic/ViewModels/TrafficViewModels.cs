namespace IntegratedProtection.Application.Traffic.ViewModels;


#region Cars View Models
public class PostCarViewModel
{

    [MaxLength(100)]
    public string Model { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }

    [MaxLength(100)]
    public string Color { get; set; }

    [MaxLength(4)]
    public string Number { get; set; }

    [MaxLength(4)]
    public string Letters { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }
}

public class PutCarViewModel
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Model { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }

    [MaxLength(100)]
    public string Color { get; set; }

    [MaxLength(4)]
    public string Number { get; set; }

    [MaxLength(4)]
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

    [MaxLength(4)]
    public string Number { get; set; }

    [MaxLength(4)]
    public string Letters { get; set; }

    public string CreatedDate { get; set; }

    public string EndDate { get; set; }

    public bool IsLicenseValid { get; set; }

    public string Plate { get; set; }

}

#endregion


