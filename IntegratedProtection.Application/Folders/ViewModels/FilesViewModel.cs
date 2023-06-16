namespace IntegratedProtection.Application.Folders.ViewModels;
public class PostFileViewModel
{
    public IFormFile file { get; set; }

    public bool IsPersonsFile { get; set; }
}
public class GetFileViewModel
{
    public string Id { get; set; }
    public string? FileName { get; set; }
    public string? StorageFileName { get; set; }
    public string? ContentType { get; set; }
    public string Base64 { get; set; }
}

