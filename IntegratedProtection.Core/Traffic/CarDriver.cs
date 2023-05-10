namespace IntegratedProtection.Core.Traffic;

[Table("CarsDrivers", Schema = "Traffic"), PrimaryKey(nameof(CarId), nameof(DriverId))]
public class CarDriver
{
    public int CarId { get; set; }

    public int DriverId { get; set; }

    [ForeignKey(name: nameof(DriverId))]
    public Driver Driver { get; set; }

    [ForeignKey(name: nameof(CarId))]
    public Car Car { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedData { get; set; }

    public CarDriver()
    {
        //CreatedData = DateTime.Now.Date;
    }
}
