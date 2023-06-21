namespace IntegratedProtection.Core.FilesEntity;
[Table("PersonFiles", Schema = "Files"), PrimaryKey(nameof(Id)), Index(nameof(FileName))]
public class PersonFile : Base<string>
{
    public PersonFile() => Id = Guid.NewGuid().ToString();
    public string SRC { get; set; }

    [MaxLength(100)]
    public string FileName { get; set; }
    public int Mode { get; set; } = 1;
}
