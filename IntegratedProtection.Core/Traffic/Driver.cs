namespace IntegratedProtection.Core.Traffic;

[Table("Drivers", Schema = "Traffic"), PrimaryKey(nameof(Id))]
public class Driver : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

    // public bool IsLicenseFounded { get; set; }

    [NotMapped]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime EndDate
    {
        get { return CreatedDate.AddYears(10).Date; }
    }

    [NotMapped]
    public bool IsLicenseValid
    {
        get
        {
            if (DateTime.Now.Year - CreatedDate.Year <= 10)
                return true;
            else
                return false;
        }
    }
    public ICollection<CarDriver> CarsDrivers { get; set; }
    public Driver()
    {
        //CreatedDate = DateTime.Now.Date;
        CarsDrivers = new HashSet<CarDriver>();
    }
}
