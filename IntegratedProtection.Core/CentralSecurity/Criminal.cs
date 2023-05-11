namespace IntegratedProtection.Core.CentralSecurity;

[Table("Criminals", Schema = "CentralSecurity"), PrimaryKey(nameof(Id))]
public class Criminal : Base<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }
    public string Reason { get; set; }

    [MaxLength(14)]
    public string SSN { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedData { get; set; }

    public Criminal()
    {
        // CreatedData = DateTime.Now.Date;

    }
}
