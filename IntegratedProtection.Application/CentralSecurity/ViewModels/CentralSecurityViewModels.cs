namespace IntegratedProtection.Application.CentralSecurity.ViewModels;


#region Criminals View Models

public class PostCriminalViewModel
{
    public string Reason { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedData { get; set; }
}


public class PutCriminalViewModel
{
    public int Id { get; set; }
    public string Reason { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedData { get; set; }
}

public class GetCriminalViewModel
{

    public int Id { get; set; }
    public string Reason { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    public string CreatedData { get; set; }

}
#endregion