namespace IntegratedProtection.Core.FilesEntity;

[Table("CarFiles", Schema = "Files"), PrimaryKey(nameof(Id)), Index(nameof(FileName))]
public class CarFile : Base<string>
{
    public CarFile() => Id = Guid.NewGuid().ToString();
    public string SRC { get; set; }

    [MaxLength(100)]
    public string FileName { get; set; }
    public int Mode { get; set; } = 0;
}


