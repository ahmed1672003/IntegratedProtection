namespace IntegratedProtection.Core.FilesEntity;
[Table("UploadedFiles", Schema = "Files"), PrimaryKey(nameof(Id))]
public class UploadedFile : Base<string>
{
    public UploadedFile() => Id = Guid.NewGuid().ToString();
    public string SRC { get; set; }
    public bool IsPersonsFile { get; set; }
}
