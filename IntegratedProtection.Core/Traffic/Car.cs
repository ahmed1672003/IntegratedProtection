namespace IntegratedProtection.Core.Traffic;

[Table("Cars", Schema = "Traffic"), PrimaryKey(nameof(Id))]
public class Car : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(100)]
    public string Model { get; set; }

    [MaxLength(14)]
    public string OwnerSSN { get; set; }

    [MaxLength(100)]
    public string Company { get; set; }

    [MaxLength(100)]
    public string Color { get; set; }

    [MaxLength(10)]
    public string Number { get; set; }

    [MaxLength(10)]
    public string Letters { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MMMM dd, yyyy", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

    public ICollection<StolenCar> StolenCars { get; set; } = new HashSet<StolenCar>();
    public ICollection<CarDriver> CarDriver { get; set; } = new HashSet<CarDriver>();

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

    [NotMapped]
    public string Plate
    {
        get
        {
            return $"{Number} - {Letters}";
        }
    }
}
