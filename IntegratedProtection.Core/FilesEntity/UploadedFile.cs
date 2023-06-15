namespace IntegratedProtection.Core.FilesEntity;
[Table("UploadedFiles", Schema = "Files"), PrimaryKey(nameof(Id)),
    Index(nameof(FileName), IsUnique = true)]
public class UploadedFile : Base<string>
{
    public UploadedFile() => Id = Guid.NewGuid().ToString();
    public string FileName { get; set; }
}
