namespace IntegratedProtection.Core.Traffic;

[Table("StolenCars", Schema = "Traffic"),
PrimaryKey(nameof(CarId), nameof(TrafficOfficerId))]
public class StolenCar
{
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    public int CarId { get; set; }
    public int TrafficOfficerId { get; set; }

    [ForeignKey(nameof(TrafficOfficerId))]
    public TrafficOfficer TrafficOfficer { get; set; } = null!;

    [ForeignKey(nameof(CarId))]
    public Car Car { get; set; } = null!;

    public StolenCar()
    {
        // CreatedDate = DateTime.Now.Date;

    }
}