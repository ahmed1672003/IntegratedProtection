namespace IntegratedProtection.Core.Traffic;

[Table("TrafficOfficers", Schema = "Traffic"), PrimaryKey(nameof(Id))]
public class TrafficOfficer : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }
    public string Code { get; set; }

    [MaxLength(100)]
    public string Center { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string MiddelName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public ICollection<StolenCar> StolenCars { get; set; }

    [NotMapped]
    public string FullName
    {
        get { return $"{FirstName} {MiddelName} {LastName}"; }
    }

    public TrafficOfficer()
    {
        StolenCars = new HashSet<StolenCar>();
    }
}
