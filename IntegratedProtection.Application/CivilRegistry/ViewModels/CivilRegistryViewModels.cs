namespace IntegratedProtection.Application.CivilRegistry.ViewModels;
#region Persons View Models
public class PostPersonViewModel
{
    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(4)]
    public string Gender { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string MiddelName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string StreetNumber { get; set; }

    [MaxLength(100)]
    public string StreetName { get; set; }

    [MaxLength(100)]
    public string Center { get; set; }

    [MaxLength(100)]
    public string Country { get; set; }
    [MaxLength(100)]
    public string Governorate { get; set; }

    [MaxLength(100)]
    public string Religion { get; set; }

    [MaxLength(100)]
    public string Status { get; set; }

    //[FromForm]
    //public IFormFile PersonPhotoFile { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }
}
public class PutPersonViewModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(4)]
    public string Gender { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string MiddelName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string StreetNumber { get; set; }

    [MaxLength(100)]
    public string StreetName { get; set; }

    [MaxLength(100)]
    public string Country { get; set; }

    [MaxLength(100)]
    public string Center { get; set; }

    [MaxLength(100)]
    public string Governorate { get; set; }

    [MaxLength(100)]
    public string Religion { get; set; }

    [MaxLength(100)]
    public string Status { get; set; }

    //[FromForm]
    //public IFormFile PersonPhotoFile { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }
}
public class GetPersonViewModel
{
    public int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(4)]
    public string Gender { get; set; }

    [MaxLength(100)]
    public string Religion { get; set; }

    [MaxLength(100)]
    public string Status { get; set; }

    [MaxLength(200)]
    public string Address { get; set; }

    [MaxLength(100)]
    public string FullName { get; set; }

    public string DateOfBirth { get; set; }

    public int Age { get; set; }

    //public string? PersonPhotoBase64 { get; set; }
}
#endregion

#region Card View Models
public class PostCardViewModel
{
    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(100)]
    public string Job { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

    public int PersonId { get; set; }

    //[FromForm]
    //public IFormFile CardPhotoFile { get; set; }

}
public class PutCardViewModel
{
    public int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(100)]
    public string Job { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

    public int PersonId { get; set; }

    //[FromForm]
    //public IFormFile CardPhotoFile { get; set; }

}
public class GetCardViewModel
{
    public int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [MaxLength(100)]
    public string Job { get; set; }

    public string CreatedDate { get; set; }

    public string EndDate { get; set; }

    public int PersonId { get; set; }

    public bool IsValid { get; set; }

    //public string? CardPhotoBase64 { get; set; }
}
#endregion

#region Person With Card View Model
public class GetPersonWithCardViewModel
{
    public GetPersonViewModel GetPersonViewModel { get; set; }
    public GetCardViewModel GetCardViewModel { get; set; }
}

#endregion