namespace IntegratedProtection.Core.Traffic;

[Table("Drivers", Schema = "Traffic"), PrimaryKey(nameof(Id))]
public class Driver : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    [NotMapped]
    public bool IsLicenseValid
    {
        get
        {
            if (Convert.ToInt32(EndDate.Year) - Convert.ToInt32(CreatedDate.Year) <= 10)
                return true;
            else
                return false;
        }
    }
    public ICollection<CarDriver> CarDriver { get; set; }
    public Driver()
    {
        CreatedDate = DateTime.Now.Date;
        EndDate = CreatedDate.AddYears(10).Date;
        CarDriver = new HashSet<CarDriver>();
    }
}
