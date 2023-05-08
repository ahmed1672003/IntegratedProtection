using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IntegratedProtection.Application.CivilRegistry.ViewModels;
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
    public string Country { get; set; }
    [MaxLength(100)]
    public string Governorate { get; set; }

    [MaxLength(100)]
    public string Religion { get; set; }

    [MaxLength(100)]
    public string Status { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }
}

[PrimaryKey(nameof(Id))]
public class PutPersonViewModel
{
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
    public string Governorate { get; set; }

    [MaxLength(100)]
    public string Religion { get; set; }

    [MaxLength(100)]
    public string Status { get; set; }

    [DataType(DataType.Date)]
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

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }

    public int Age { get; set; }
}

