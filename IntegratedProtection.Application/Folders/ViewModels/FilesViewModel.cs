using System.Text.Json.Serialization;

namespace IntegratedProtection.Application.Folders.ViewModels;
public class PostFileViewModel
{
    [JsonIgnore]
    public IFormFile file { get; set; }

    public string? FileFullPath { get; set; }

    public bool IsPersonFile { get; set; }
}
public class GetFileViewModel
{
    public string Id { get; set; }
    public string FileFullPath { get; set; }
    public string Base64String { get; set; }
}

