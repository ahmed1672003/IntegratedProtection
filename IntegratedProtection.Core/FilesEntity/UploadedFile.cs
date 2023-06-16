namespace IntegratedProtection.Core.FilesEntity;
[Table("UploadedFiles", Schema = "Files"),
PrimaryKey(nameof(Id)),
Index(nameof(FileFullPath), IsUnique = true)]
public class UploadedFile : Base<string>
{
    public UploadedFile() => Id = Guid.NewGuid().ToString();
    public string FileFullPath { get; set; }
    public bool IsPersonFile { get; set; }

}
