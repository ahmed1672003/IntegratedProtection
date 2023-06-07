namespace IntegratedProtection.Core.CivilRegistry;

[Table("Persons", Schema = "CivilRegistry"), PrimaryKey(nameof(Id))]
public class Person : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

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

    //[MaxLength(1024 * 1025 * 4)]
    //public byte[]? PersonalPhoto { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }
    public Card Card { get; set; }

    [NotMapped]
    public string FullName
    {
        get
        {
            return $"{FirstName} {MiddelName} {LastName}";
        }
    }
    [NotMapped]
    public string Address
    {
        get
        {
            return $"[{StreetNumber}, {StreetName}]-{Center}-{Governorate}-{Country}";
        }
    }

    [NotMapped]
    public int Age
    {
        get
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }
}


