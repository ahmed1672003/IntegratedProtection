namespace IntegratedProtection.Core.FilesEntity;
[Table("UploadedFiles", Schema = "Files"), PrimaryKey(nameof(Id))]
public class UploadedFile : Base<string>
{
    public UploadedFile() => Id = Guid.NewGuid().ToString();
    public string FileName { get; set; }
    public byte[] File { get; set; }
    public string ContentType { get; set; }
    public bool IsPersonsFile { get; set; }
}
