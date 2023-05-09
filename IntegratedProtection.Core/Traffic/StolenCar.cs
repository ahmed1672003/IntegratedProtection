namespace IntegratedProtection.Core.Traffic;

[Table("StolenCars", Schema = "Traffic"),
PrimaryKey(nameof(CarId), nameof(TrafficOfficerId))]
public class StolenCar
{
    public int CarId { get; set; }
    public int TrafficOfficerId { get; set; }

    [ForeignKey(nameof(TrafficOfficerId))]
    public TrafficOfficer TrafficOfficer { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car Car { get; set; }
}